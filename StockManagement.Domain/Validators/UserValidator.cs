using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;
using System.Net;

namespace StockManagement.Domain.Validators
{
    public class UserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<User> AddUserValidation(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
                return Result<User>.Failure("Username is required", HttpStatusCode.BadRequest);

            if (string.IsNullOrEmpty(user.FirstName))
                return Result<User>.Failure("First name is required", HttpStatusCode.BadRequest);

            if (string.IsNullOrEmpty(user.LastName))
                return Result<User>.Failure("Last name is required", HttpStatusCode.BadRequest);

            if (!Enum.IsDefined(typeof(Roles), user.Role))
                return Result<User>.Failure("Role is not valid", HttpStatusCode.BadRequest);

            return Result<User>.Success(user);
        }
    }
}
