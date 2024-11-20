using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using StockManagement.Domain.Validators;
using System.Net;

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

        public Result<FetchProductsModel> FetchProducts(string name, string description, int pageNumber = 1, int pageSize = 10)
        {
            FetchProductsModel productsModel = _productRepository.FetchAsync(name, description, pageNumber, pageSize).Result;

            if (productsModel == null)
                return Result<FetchProductsModel>.Failure("Could not fetch products", HttpStatusCode.InternalServerError);

            return Result<FetchProductsModel>.Success(productsModel);
        }

        public Result<Product> GetProductById(int id)
        {   
            var result = _validator.GetByIdValidation(id);
            
            if (result.isSuccess == false)
                return result;
            
            Product product = _productRepository.GetByIdAsync(id).Result;

            if (product == null)            
                return Result<Product>.Failure($"Product with id {id} was not found", HttpStatusCode.NotFound);

            return Result<Product>.Success(product);
        }

        public Result<Product> AddProduct(Product product) 
        {
            var result = _validator.AddProductValidation(product);

            if (result.isSuccess == false)
                return result;

            product = _productRepository.AddAsync(product).Result;

            if (product == null || product.Id <= 0)
                return Result<Product>.Failure("Product was not added", HttpStatusCode.InternalServerError);

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
                return Result<Product>.Failure($"Product with id {id} was not found", HttpStatusCode.NotFound);

            _productRepository.Delete(product);

            return Result<Product>.Success(product);
        }
    }
}
