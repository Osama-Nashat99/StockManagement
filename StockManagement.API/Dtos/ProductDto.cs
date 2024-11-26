using StockManagement.Domain.Enums;

namespace StockManagement.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string? SerialNumber { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public ProductStatus Status { get; set; }
        public string? IssuedFor { get; set; }
    }
}
