using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;
using System.Net;

namespace StockManagement.Domain.Validators
{
    public class ProductValidator
    {
        private readonly IProductRepository _productRepository;

        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Result<Product> AddProductValidation(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                return Result<Product>.Failure("Product name is required", HttpStatusCode.BadRequest);

            if (!Enum.IsDefined(typeof(Categories), product.Category))
                return Result<Product>.Failure("Product category is not defined", HttpStatusCode.BadRequest);

            if (product.Price < 0)
                return Result<Product>.Failure("Product price should be greater than 0", HttpStatusCode.BadRequest);

            if (product.Quantity < 0)
                return Result<Product>.Failure("Product quantity should be greater than 0", HttpStatusCode.BadRequest);

            return Result<Product>.Success(product);
        }

        public Result<Product> UpdateProductValidation(int id, Product product)
        {
            if (id == 0)
                return Result<Product>.Failure("Id should be greater than 0", HttpStatusCode.BadRequest);

            if (_productRepository.GetByIdAsync(id).Result == null)
                return Result<Product>.Failure($"Product with id {id} was not found", HttpStatusCode.NotFound);

            if (string.IsNullOrEmpty(product.Name))
                return Result<Product>.Failure("Product name is required", HttpStatusCode.BadRequest);

            if (!Enum.IsDefined(typeof(Categories), product.Category))
                return Result<Product>.Failure("Product category is not defined", HttpStatusCode.BadRequest);

            if (product.Price < 0)
                return Result<Product>.Failure("Product price should be greater than 0", HttpStatusCode.BadRequest);

            if (product.Quantity < 0)
                return Result<Product>.Failure("Product quantity should be greater than 0", HttpStatusCode.BadRequest);

            return Result<Product>.Success(product);
        }

        public Result<Product> GetByIdValidation(int id)
        {
            if (id == 0)
                return Result<Product>.Failure("Id should be greater than 0", HttpStatusCode.BadRequest);

            return Result<Product>.Success(default);
        }

        public Result<Product> DeleteProductValidation(int id)
        {
            if (id == 0)
                return Result<Product>.Failure("Id should be greater than 0", HttpStatusCode.BadRequest);

            return Result<Product>.Success(default);
        }
    }
}
