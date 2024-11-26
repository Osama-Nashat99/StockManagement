using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.Linq.Expressions;

namespace StockManagement.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.categories.ToListAsync();
        }

        public void Delete(Category category)
        {
            _db.Remove(category);
            _db.SaveChanges();
        }

        public async Task<Category> GetById(int id)
        {
            return await _db.categories.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<FetchModel<Category>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Category> model = new FetchModel<Category>();

            IQueryable<Category> categoriesQuery = _db.categories.AsQueryable();

            model.TotalEntities = await categoriesQuery.CountAsync();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                categoriesQuery = categoriesQuery.Where(c =>
                    (c.Name != null && EF.Functions.Like(c.Name, $"%{searchFilter}%"))
                );
            }

            var parameter = Expression.Parameter(typeof(Category), "c");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<Category, object>>(Expression.Convert(property, typeof(object)), parameter);

            categoriesQuery = sortDirection.ToLower() == "asc"
                ? categoriesQuery.OrderBy(lambda)
                : categoriesQuery.OrderByDescending(lambda);

            var categoriesList = await categoriesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Entities = categoriesList;

            return model;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _db.categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }
    }
}
