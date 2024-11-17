using StockManagement.Domain.Enums;

namespace StockManagement.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Categories Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
