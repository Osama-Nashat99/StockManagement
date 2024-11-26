using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;

namespace StockManagement.Domain.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? SerialNumber { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public ProductStatus Status { get; set; }
        public string? IssuedFor { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
