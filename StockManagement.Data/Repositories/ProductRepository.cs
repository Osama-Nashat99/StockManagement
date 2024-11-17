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
            return await _db.products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _db.products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public Product Update(Product product)
        {
            _db.products.Update(product);
            _db.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
        }
    }
}
