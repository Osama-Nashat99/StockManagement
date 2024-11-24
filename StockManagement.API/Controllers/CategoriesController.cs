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
        public IActionResult Get()
        {
            var result = _categoryService.Get();

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(CategoryMapper.ToCategoryDto(result.value));
        }
    }
}
