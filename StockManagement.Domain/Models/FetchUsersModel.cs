using StockManagement.Domain.Entities;

namespace StockManagement.Domain.Models
{
    public class FetchUsersModel
    {
        public FetchUsersModel()
        {
            this.Users = new List<User>();
        }

        public int TotalUsers { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
