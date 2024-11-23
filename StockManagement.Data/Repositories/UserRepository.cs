using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;

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

        public async Task<User> Get(string username, string password)
        {
            return await _db.users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        // to verify user on login
        public bool VerifyPassword(User user, string enteredPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
