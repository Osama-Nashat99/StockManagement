using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public static class ProductsMapper
    {

        public static FetchProductsDto ToProductDto(FetchProductsModel model)
        {
            FetchProductsDto dto = new FetchProductsDto();

            dto.TotalProducts = model.TotalProducts;

            dto.Products = model.Products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Price = p.Price,
                Quantity = p.Quantity
            });

            return dto;
        }

        public static ProductDto ToProductDto(Product product) 
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static AddProductDto ToAddProductDto(Product product)
        {
            return new AddProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
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
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
        }
    }
}
