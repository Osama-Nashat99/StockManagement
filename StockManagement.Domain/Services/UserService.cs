using StockManagement.Domain.Entities;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using StockManagement.Domain.Validators;
using System.Net;

namespace StockManagement.Domain.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private readonly UserValidator _validator;

        public UserService(IUserRepository userRepository, UserValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public FetchModel<User> FetchUsers(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<User> usersModel = _userRepository.FetchAsync(pageNumber, pageSize, searchFilter, sortBy, sortDirection).Result;

            if (usersModel == null)
                throw new Exception("Could not fetch users");

            return usersModel;
        }

        public User Get(string username, string password) 
        { 
            User user = _userRepository.Get(username, password).Result;

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }

        public User GetByUsername(string username) 
        {
            User user = _userRepository.GetByUsername(username).Result;

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }

        public User AddUser(User user) {

            var result = _validator.AddUserValidation(user);

            var searchedUser = GetByUsername(user.Username);

            if (searchedUser != null)
                throw new BadRequestException("Username is already used");

            user = _userRepository.Create(user).Result;

            if (user == null || user.Id <= 0)
                throw new Exception("User was not added");

            return user;
        }

        public User UpdatePassword(int id, string password)
        {
            User user = _userRepository.UpdatePassword(id, password);

            if (user == null)
                throw new NotFoundException("User was not found");

            return user;
        }
    }
}
