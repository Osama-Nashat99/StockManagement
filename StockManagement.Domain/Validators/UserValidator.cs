using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Exceptions;
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

        public void AddUserValidation(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
                throw new BadRequestException("Username is required");

            if (string.IsNullOrEmpty(user.FirstName))
                throw new BadRequestException("First name is required");

            if (string.IsNullOrEmpty(user.LastName))
                throw new BadRequestException("Last name is required");

            if (!Enum.IsDefined(typeof(Roles), user.Role))
                throw new BadRequestException("Role is not valid");
        }
    }
}
