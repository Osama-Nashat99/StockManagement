using StockManagement.Domain.Entities;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
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

        public FetchModel<Product> FetchProducts(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Product> productsModel = _productRepository.FetchAsync(pageNumber, pageSize, searchFilter, sortBy, sortDirection).Result;

            if (productsModel == null)
                throw new Exception("Could not fetch products");

            return productsModel; 
        }

        public Product GetProductById(int id)
        {   
            _validator.GetByIdValidation(id);
            
            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)
                throw new NotFoundException($"Product with id {id} was not found");

            return product;
        }

        public Product AddProduct(Product product) 
        {
            _validator.AddProductValidation(product);

            product = _productRepository.AddAsync(product).Result;

            if (product == null || product.Id <= 0)
                throw new Exception("Product was not added");

            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            _validator.UpdateProductValidation(id, product);

            product.Id = id;
            product = _productRepository.Update(product);

            return product;
        }

        public Product DeleteProduct(int id)
        {
            _validator.DeleteProductValidation(id);

            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)
                throw new NotFoundException($"Product with id {id} was not found");

            _productRepository.Delete(product);
            return product;
        }
    }
}
