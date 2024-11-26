using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<FetchModel<Product>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc");
        Task<Product> AddAsync(Product product);
        Product Update(Product product);
        void Delete(Product product);
        Task<bool> IsSerialNumberExistsAsync(string serialNumber);
    }
}
