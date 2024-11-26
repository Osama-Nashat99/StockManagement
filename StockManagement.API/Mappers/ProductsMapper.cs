using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public static class ProductsMapper
    {

        public static FetchDto<ProductDto> ToProductDto(FetchModel<Product> model)
        {
            FetchDto<ProductDto> dto = new FetchDto<ProductDto>();

            dto.TotalEntities = model.TotalEntities;

            dto.Entities = model.Entities.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Price = p.Price,
                SerialNumber = p.SerialNumber,
                StoreId = p.StoreId,
                StoreName = p.Store.Name,
                Status = p.Status,
                IssuedFor = p.IssuedFor
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
                SerialNumber = product.SerialNumber,
                StoreId = product.StoreId,
                StoreName = product.Store.Name,
                Status = product.Status,
                IssuedFor = product.IssuedFor
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
                SerialNumber = product.SerialNumber,
                StoreId = product.StoreId,
                Status = product.Status,
                IssuedFor = product.IssuedFor
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
                SerialNumber = dto.SerialNumber,
                StoreId = dto.StoreId,
                Status = dto.Status,
                IssuedFor = dto.IssuedFor
            };
        }
    }
}
