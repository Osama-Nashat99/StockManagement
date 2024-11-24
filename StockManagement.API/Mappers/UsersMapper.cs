using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public class UsersMapper
    {
        public static FetchUsersDto ToUserDto(FetchUsersModel model)
        {
            FetchUsersDto dto = new FetchUsersDto();

            dto.TotalUsers = model.TotalUsers;

            dto.Users = model.Users.Select(p => new UserDto()
            {
                Id = p.Id,
                Username = p.Username,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = p.Role
            });

            return dto;
        }

        public static UserDto ToUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role
            };
        }

        public static User ToUserEntity(UserDto dto)
        {
            return new User()
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = dto.Role
            };
        }
    }
}
