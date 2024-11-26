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
        private readonly IStoreRepository _storeRepository;

        public ProductValidator(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            _productRepository = productRepository;
            _storeRepository = storeRepository;
        }

        public void AddProductValidation(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                throw new BadRequestException("Product name is required");

            if (string.IsNullOrEmpty(product.Description))
                throw new BadRequestException("Product description is required");

            if (product.Price < 0)
                throw new BadRequestException("Product price should be greater than 0");

            if (!string.IsNullOrEmpty(product.SerialNumber))
            {
                bool isSerialNumberExists = _productRepository.IsSerialNumberExistsAsync(product.SerialNumber).Result;

                if (isSerialNumberExists)
                    throw new BadRequestException("Serial number is already used");
            }

            if (Enum.IsDefined(typeof(ProductStatus), product.Status) == false)
                throw new BadRequestException("Product status is not defined");

            bool isStoreExists = _storeRepository.IsStoreExistsAsync(product.StoreId).Result;
            if (isStoreExists == false)
                throw new BadRequestException("Store doesn't exist");

            if (product.Status == ProductStatus.Issued && string.IsNullOrEmpty(product.IssuedFor))
                throw new BadRequestException("Product issued for is required for issued products");
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

            if (string.IsNullOrEmpty(product.Description))
                throw new BadRequestException("Product description is required");

            if (product.Price < 0)
                throw new BadRequestException("Product price should be greater than 0");

            if (Enum.IsDefined(typeof(ProductStatus), product.Status) == false)
                throw new BadRequestException("Product status is not defined");

            bool isStoreExists = _storeRepository.IsStoreExistsAsync(product.StoreId).Result;
            if (isStoreExists == false)
                throw new BadRequestException("Store doesn't exist");

            if (product.Status == ProductStatus.Issued && string.IsNullOrEmpty(product.IssuedFor))
                throw new BadRequestException("Product issued for is required for issued products");
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
