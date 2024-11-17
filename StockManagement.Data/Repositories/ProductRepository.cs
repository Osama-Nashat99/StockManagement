using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;

namespace StockManagement.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.products.FindAsync(id);
        }

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _db.products.AddAsync(product);
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
