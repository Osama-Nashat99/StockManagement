using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.Linq.Expressions;

namespace StockManagement.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<FetchModel<Product>> FetchAsync(int pageNumber = 1, int pageSize = 10, string search = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Product> model = new FetchModel<Product>();

            IQueryable<Product> productsQuery = _db.products.Include(p => p.Category).AsQueryable();

            model.TotalEntities = await productsQuery.CountAsync();

            if (!string.IsNullOrEmpty(search))
            {
                productsQuery = productsQuery.Where(p =>
                    (p.Name != null && EF.Functions.Like(p.Name, $"%{search}%")) ||
                    (p.Description != null && EF.Functions.Like(p.Description, $"%{search}%"))
                );
            }

            var parameter = Expression.Parameter(typeof(Product), "p");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<Product, object>>(Expression.Convert(property, typeof(object)), parameter);

            productsQuery = sortDirection.ToLower() == "asc"
                ? productsQuery.OrderBy(lambda)
                : productsQuery.OrderByDescending(lambda);

            var productsList = await productsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Entities = productsList;

            return model;

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.products.Include(p => p.Category).AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
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
