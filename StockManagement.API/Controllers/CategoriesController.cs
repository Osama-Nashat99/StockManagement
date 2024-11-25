using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
using StockManagement.Domain.Services;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet()]
        public IEnumerable<CategoryDto> Get()
        {
            var categories = _categoryService.Get();
            return CategoryMapper.ToCategoryDto(categories);
        }

        [HttpPost("fetch")]
        public FetchDto<CategoryDto> FetchCategories([FromBody] FilterDto filterDto)
        {
            var fetchCategoryModel = _categoryService.FetchCategories(filterDto.PageNumber, filterDto.PageSize, filterDto.Search, filterDto.SortBy, filterDto.SortDirection);
            return CategoryMapper.ToCategoryDto(fetchCategoryModel);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public CategoryDto Post([FromBody] CategoryDto categoryDto)
        {
            var username = HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var category = CategoryMapper.ToCategoryEntity(categoryDto);
            category.CreatedBy = username;
            category = _categoryService.AddCategory(category);
            return CategoryMapper.ToCategoryDto(category);
        }
    }
}
