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

        // GET: api/products
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] string? name, [FromQuery] string? description, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = _productService.FetchProducts(name, description, pageNumber, pageSize);

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(ProductsMapper.ToProductDto(result.value));
            }
            catch (Exception ex) { 
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _productService.GetProductById(id);

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(ProductsMapper.ToProductDto(result.value));
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/products
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto product)
        {
            try
            {
                var result = _productService.AddProduct(ProductsMapper.ToProductEntity(product));

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(ProductsMapper.ToProductDto(result.value));
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT api/products/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto product)
        {
            try
            {
                var result = _productService.UpdateProduct(id, ProductsMapper.ToProductEntity(product));

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(ProductsMapper.ToProductDto(result.value));
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE api/<ProductsController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _productService.DeleteProduct(id);

                if (result.isSuccess == false)
                    return StatusCode(result.code.GetHashCode(), result.message);

                return Ok(ProductsMapper.ToProductDto(result.value));
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
