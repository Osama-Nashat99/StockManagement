using StockManagement.Domain.Entities;

namespace StockManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Product Update(Product product);
        void Delete(Product product);
        Task SaveAsync();
    }
}
