using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
using StockManagement.Domain.Enums;
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
        public FetchDto<ProductDto> FetchProducts([FromBody] FilterDto filterProductsDto)
        {
            var result = _productService.FetchProducts(filterProductsDto.PageNumber, filterProductsDto.PageSize, filterProductsDto.Search, filterProductsDto.SortBy, filterProductsDto.SortDirection);
            return ProductsMapper.ToProductDto(result);
        }

        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            var product = _productService.GetProductById(id);
            return ProductsMapper.ToProductDto(product);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public AddProductDto Post([FromBody] ProductDto productDto)
        {
            var username = HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var product = ProductsMapper.ToProductEntity(productDto);
            product.CreatedBy = username;

            if (string.IsNullOrEmpty(product.SerialNumber))
                product.SerialNumber = null;

            if (string.IsNullOrEmpty(product.IssuedFor))
                product.IssuedFor = null;

            product = _productService.AddProduct(product);
            return ProductsMapper.ToAddProductDto(product);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public AddProductDto Put(int id, [FromBody] ProductDto productDto)
        {
            var username = HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var product = ProductsMapper.ToProductEntity(productDto);
            product.ModifiedDate = DateTime.Now;
            product.ModifiedBy = username;

            if (string.IsNullOrEmpty(product.SerialNumber))
                product.SerialNumber = null;

            if (string.IsNullOrEmpty(product.IssuedFor) || product.Status != ProductStatus.Issued)
                product.IssuedFor = null;

            product = _productService.UpdateProduct(id, product);
            return ProductsMapper.ToAddProductDto(product);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public ProductDto Delete(int id)
        {
            var product = _productService.DeleteProduct(id);
            return ProductsMapper.ToProductDto(product);
        }
    }
}
