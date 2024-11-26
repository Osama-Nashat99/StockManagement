using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using System.Net;

namespace StockManagement.Domain.Validators
{
    public class ProductValidator
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProductValidation(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                throw new BadRequestException("Product name is required");

            if (product.Price < 0)
                throw new BadRequestException("Product price should be greater than 0");
        }

        public void UpdateProductValidation(int id, Product product)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");

            var oldProduct = _productRepository.GetByIdAsync(id).Result;

            if (oldProduct == null)
                throw new NotFoundException($"Product with id {id} was not found");

            product.CreatedBy = oldProduct.CreatedBy;
            product.CreatedDate = oldProduct.CreatedDate;

            if (string.IsNullOrEmpty(product.Name))
                throw new BadRequestException("Product name is required");

            if (product.Price < 0)
                throw new BadRequestException("Product price should be greater than 0");
        }

        public void GetByIdValidation(int id)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");
        }

        public void DeleteProductValidation(int id)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");
        }
    }
}
