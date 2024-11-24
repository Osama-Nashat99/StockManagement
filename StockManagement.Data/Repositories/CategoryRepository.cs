using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;

namespace StockManagement.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _db.categories.ToListAsync();
        }
    }
}
