using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public class UsersMapper
    {
        public static FetchDto<UserDto> ToUserDto(FetchModel<User> model)
        {
            FetchDto<UserDto> dto = new FetchDto<UserDto>();

            dto.TotalEntities = model.TotalEntities;

            dto.Entities = model.Entities.Select(u => new UserDto()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role
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
