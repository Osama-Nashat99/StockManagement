using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public class CategoryMapper
    {
        public static IEnumerable<CategoryDto> ToCategoryDto(IEnumerable<Category> model)
        {
            return model.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public static CategoryDto ToCategoryDto(Category model)
        {
            return new CategoryDto()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static FetchDto<CategoryDto> ToCategoryDto(FetchModel<Category> model)
        {
            FetchDto<CategoryDto> dto = new FetchDto<CategoryDto>();

            dto.TotalEntities = model.TotalEntities;

            dto.Entities = model.Entities.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name= c.Name,
            });

            return dto;
        }

        public static Category ToCategoryEntity(CategoryDto dto)
        {
            return new Category()
            {
                Name = dto.Name
            };
        }
    }
}
