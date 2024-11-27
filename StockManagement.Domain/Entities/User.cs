using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;

namespace StockManagement.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public bool IsFirstLogin { get; set; }
        public Store? Store { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
