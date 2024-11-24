using StockManagement.Domain.Enums;

namespace StockManagement.API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Roles Role { get; set; }
    }
}
