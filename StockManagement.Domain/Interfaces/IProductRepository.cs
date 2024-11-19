using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<FetchProductsModel> FetchAsync(string name, string description, int pageNumber = 1, int pageSize = 10);
        Task<Product> AddAsync(Product product);
        Product Update(Product product);
        void Delete(Product product);
        Task SaveAsync();
    }
}
