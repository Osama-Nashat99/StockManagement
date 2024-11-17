using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;

namespace StockManagement.API.Mappers
{
    public static class ProductsMapper
    {
        public static IEnumerable<ProductDto> ToProductDto(IEnumerable<Product> products)
        {
            return products.Select(p => new ProductDto() { 
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Price = p.Price,
                Quantity = p.Quantity 
            });
        }
    }
}
