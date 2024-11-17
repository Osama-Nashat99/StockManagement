using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Validators;
using System.Reflection.Metadata.Ecma335;
using System.Xml.XPath;

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
            if (id == 0)            
                return Result<Product>.Failure("Id should be greater than 0");            
            
            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)            
                return Result<Product>.Failure($"Product with id {id} was not found");

            return Result<Product>.Success(product);
        }

        public Result<Product> AddProduct(Product product) 
        {
            if (string.IsNullOrEmpty(product.Name)) 
                return Result<Product>.Failure("Product name is required");

            if (!Enum.IsDefined(typeof(Categories), product.Category))
                return Result<Product>.Failure("Product category is not defined");

            if (product.Price < 0)
                return Result<Product>.Failure("Product price should be greater than 0");

            if (product.Quantity < 0) 
                return Result<Product>.Failure("Product quantity should be greater than 0");

            product = _productRepository.AddAsync(product).Result;

            if (product == null || product.Id <= 0)
                return Result<Product>.Failure("Product was not added");

            return Result<Product>.Success(product);
        }

        public Result<Product> UpdateProduct(int id, Product product)
        {
            if (id == 0)
                return Result<Product>.Failure("Id should be greater than 0");

            if (_productRepository.GetByIdAsync(id).Result == null)
                return Result<Product>.Failure($"Product with id {id} was not found");

            if (string.IsNullOrEmpty(product.Name))
                return Result<Product>.Failure("Product name is required");

            if (!Enum.IsDefined(typeof(Categories), product.Category))
                return Result<Product>.Failure("Product category is not defined");

            if (product.Price < 0)
                return Result<Product>.Failure("Product price should be greater than 0");

            if (product.Quantity < 0)
                return Result<Product>.Failure("Product quantity should be greater than 0");

            product.Id = id;

            product = _productRepository.Update(product);

            return Result<Product>.Success(product);
        }

        public Result<Product> DeleteProduct(int id)
        {
            if (id == 0)
                return Result<Product>.Failure("Id should be greater than 0");

            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)
                return Result<Product>.Failure($"Product with id {id} was not found");

            _productRepository.Delete(product);

            return Result<Product>.Success(product);
        }
    }
}
