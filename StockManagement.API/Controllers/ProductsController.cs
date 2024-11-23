using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
using StockManagement.Domain.Services;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("fetch")]
        public IActionResult FetchProducts([FromBody] FilterProductsDto filterProductsDto)
        {
            var result = _productService.FetchProducts(filterProductsDto.PageNumber, filterProductsDto.PageSize, filterProductsDto.SearchFilter, filterProductsDto.SortBy, filterProductsDto.SortDirection);

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(ProductsMapper.ToProductDto(result.value));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetProductById(id);

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(ProductsMapper.ToProductDto(result.value));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto product)
        {
            var result = _productService.AddProduct(ProductsMapper.ToProductEntity(product));

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(ProductsMapper.ToProductDto(result.value));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto product)
        {
            var result = _productService.UpdateProduct(id, ProductsMapper.ToProductEntity(product));

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(ProductsMapper.ToProductDto(result.value));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);

            if (result.isSuccess == false)
                return StatusCode(result.code.GetHashCode(), result.message);

            return Ok(ProductsMapper.ToProductDto(result.value));
        }
    }
}
