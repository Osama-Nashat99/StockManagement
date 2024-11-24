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
    }
}
