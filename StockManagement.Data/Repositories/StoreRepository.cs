using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.Linq.Expressions;

namespace StockManagement.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _db;

        public StoreRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<Store> AddAsync(Store store)
        {
            await _db.stores.AddAsync(store);
            await _db.SaveChangesAsync();
            return store;
        }

        public void Delete(Store store)
        {
            _db.Remove(store);
            _db.SaveChanges();
        }

        public async Task<FetchModel<Store>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Store> model = new FetchModel<Store>();

            IQueryable<Store> storesQuery = _db.stores.Include(s => s.StoreKeeper).AsQueryable();

            model.TotalEntities = await storesQuery.CountAsync();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                storesQuery = storesQuery.Where(p =>
                    (p.Name != null && EF.Functions.Like(p.Name, $"%{searchFilter}%"))
                );
            }

            var parameter = Expression.Parameter(typeof(Store), "s");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<Store, object>>(Expression.Convert(property, typeof(object)), parameter);

            storesQuery = sortDirection.ToLower() == "asc"
                ? storesQuery.OrderBy(lambda)
                : storesQuery.OrderByDescending(lambda);

            var storesList = await storesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Entities = storesList;

            return model;
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            return await _db.stores.Include(s => s.StoreKeeper).ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await _db.stores.AsNoTracking().Include(s => s.StoreKeeper).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> IsStoreExistsAsync(int id)
        {
            return await _db.stores.AnyAsync(p => p.Id == id);
        }

        public Store Update(Store store)
        {
            _db.stores.Update(store);
            _db.SaveChanges();
            return store;
        }
    }
}
