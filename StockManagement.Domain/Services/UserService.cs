using StockManagement.Domain.Entities;
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

        public Result<FetchUsersModel> FetchUsers(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchUsersModel usersModel = _userRepository.FetchAsync(pageNumber, pageSize, searchFilter, sortBy, sortDirection).Result;

            if (usersModel == null)
                return Result<FetchUsersModel>.Failure("Could not fetch users", HttpStatusCode.InternalServerError);

            return Result<FetchUsersModel>.Success(usersModel);
        }

        public Result<User> Get(string username, string password) { 
            User user = _userRepository.Get(username, password).Result;

            if (user == null)
                return Result<User>.Failure("User not found", HttpStatusCode.NotFound);

            return Result<User>.Success(user);
        }

        public Result<User> GetByUsername(string username) {
            User user = _userRepository.GetByUsername(username).Result;

            if (user == null)
                return Result<User>.Failure("User not found", HttpStatusCode.NotFound);

            return Result<User>.Success(user);
        }

        public Result<User> AddUser(User user) {

            var result = _validator.AddUserValidation(user);

            if (result.isSuccess == false)
                return result;

            result = GetByUsername(user.Username);

            if (result.isSuccess)
                return Result<User>.Failure("Username is already used", HttpStatusCode.BadRequest);

            user = _userRepository.Create(user).Result;

            if (user == null || user.Id <= 0)
                return Result<User>.Failure("User was not added", HttpStatusCode.InternalServerError);

            return Result<User>.Success(user);
        }

        public Result<User> UpdatePassword(int id, string password)
        {
            User user = _userRepository.UpdatePassword(id, password);

            if (user == null)
                return Result<User>.Failure("User was not found", HttpStatusCode.NotFound);

            return Result<User>.Success(user);
        }
    }
}
