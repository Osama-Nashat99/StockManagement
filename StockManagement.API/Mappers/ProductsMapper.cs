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

        public static ProductDto ToProductDto(Product product) 
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static Product ToProductEntity(ProductDto dto) 
        {
            return new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
        }
    }
}
