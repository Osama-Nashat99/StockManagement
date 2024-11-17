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

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = _productRepository.GetAllAsync().Result;
            return products;
        }
    }
}
