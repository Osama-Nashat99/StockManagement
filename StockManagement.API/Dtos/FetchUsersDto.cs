namespace StockManagement.API.Dtos
{
    public class FetchUsersDto
    {
        public FetchUsersDto()
        {
            this.Users = new List<UserDto>();
        }

        public int TotalUsers { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
