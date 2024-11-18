using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Validators;

namespace StockManagement.Domain.Services
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        private readonly ProductValidator _validator;

        public ProductService(IProductRepository productRepository, ProductValidator productValidator)
        {
            _productRepository = productRepository;
            _validator = productValidator;
        }

        public Result<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = _productRepository.GetAllAsync().Result;

            if (products == null || products.Count() == 0)
                return Result<IEnumerable<Product>>.Failure("No Products are available");

            return Result<IEnumerable<Product>>.Success(products);
        }

        public Result<Product> GetProductById(int id)
        {   
            var result = _validator.GetByIdValidation(id);
            
            if (result.isSuccess == false)
                return result;
            
            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)            
                return Result<Product>.Failure($"Product with id {id} was not found");

            return Result<Product>.Success(product);
        }

        public Result<Product> AddProduct(Product product) 
        {
            var result = _validator.AddProductValidation(product);

            if (result.isSuccess == false)
                return result;

            product = _productRepository.AddAsync(product).Result;

            if (product == null || product.Id <= 0)
                return Result<Product>.Failure("Product was not added");

            return Result<Product>.Success(product);
        }

        public Result<Product> UpdateProduct(int id, Product product)
        {
            var result = _validator.UpdateProductValidation(id, product);

            if (result.isSuccess == false)
                return result;

            product.Id = id;
            product = _productRepository.Update(product);

            return Result<Product>.Success(product);
        }

        public Result<Product> DeleteProduct(int id)
        {
            var result = _validator.DeleteProductValidation(id);

            if (result.isSuccess == false)
                return result;

            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)
                return Result<Product>.Failure($"Product with id {id} was not found");

            _productRepository.Delete(product);

            return Result<Product>.Success(product);
        }
    }
}
