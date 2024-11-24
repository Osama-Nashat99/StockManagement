﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.Linq.Expressions;

namespace StockManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<FetchModel<User>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<User> model = new FetchModel<User>();

            IQueryable<User> usersQuery = _db.users.AsQueryable();

            model.TotalEntities = await usersQuery.CountAsync();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                usersQuery = usersQuery.Where(u =>
                    (u.Username != null && EF.Functions.Like(u.Username, $"%{searchFilter}%"))
                );
            }

            var parameter = Expression.Parameter(typeof(User), "u");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<User, object>>(Expression.Convert(property, typeof(object)), parameter);

            usersQuery = sortDirection.ToLower() == "asc"
                ? usersQuery.OrderBy(lambda)
                : usersQuery.OrderByDescending(lambda);

            var usersList = await usersQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Entities = usersList;

            return model;

        }

        public async Task<User> Get(string username, string password)
        {
            return await _db.users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _db.users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> Create(User user)
        {
            user.Password = "pass123";
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            user.IsFirstLogin = true;
            await _db.users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public User UpdatePassword(int id, string password)
        {
            User user = _db.users.Find(id);

            if (user == null)
                return user;

            user.Password = _passwordHasher.HashPassword(user, password);
            user.IsFirstLogin = false;
            user.ModifiedBy = user.Username;
            user.ModifiedDate = DateTime.Now;
            _db.Update(user);
            _db.SaveChanges();
            return user;
        }

        public bool VerifyPassword(User user, string enteredPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
