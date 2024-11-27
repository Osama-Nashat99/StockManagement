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

        public User GetByUsername(string username) 
        {
            User user = _userRepository.GetByUsername(username).Result;
            return user;
        }

        public User AddUser(User user) {

            _validator.AddUserValidation(user);

            var searchedUser = GetByUsername(user.Username);

            if (searchedUser != null)
                throw new BadRequestException("Username is already used");

            user = _userRepository.AddAsync(user).Result;

            if (user == null || user.Id <= 0)
                throw new Exception("User was not added");

            return user;
        }

        public User UpdatePassword(int id, string password)
        {
            User user = _userRepository.UpdatePassword(id, password);
            return user;
        }

        public User DeleteUser(int id)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");

            User user = _userRepository.GetByIdAsync(id).Result;

            if (user == null)
                throw new NotFoundException($"User with id {id} was not found");

            _userRepository.Delete(user);
            return user;
        }

        public IEnumerable<User> GetStoreKeepers() 
        {
            IEnumerable<User> users = _userRepository.GetStoreKeepers().Result;
            return users;
        }
    }
}
