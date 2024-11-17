using StockManagement.Domain.Entities;
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
            Result<IEnumerable<Product>> result;

            IEnumerable<Product> products = _productRepository.GetAllAsync().Result;

            if (products == null || products.Count() == 0)
                result = Result<IEnumerable<Product>>.Failure("No Products are available");

            result = Result<IEnumerable<Product>>.Success(products);

            return result;
        }

        public Product GetProductById(int id)
        {   
            
            Product product = _productRepository.GetByIdAsync(id).Result;
            return product;
        }
    }
}
