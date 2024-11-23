using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.Globalization;
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

        //public async Task<FetchProductsModel> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        //{
        //    FetchProductsModel model = new FetchProductsModel();

        //    model.Products = _db.products.AsQueryable();

        //    model.TotalProducts = model.Products.Count();

        //    if (!string.IsNullOrEmpty(searchFilter))
        //    {
        //        model.Products = model.Products.Where(p =>
        //                (!string.IsNullOrEmpty(p.Name) && p.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase)) ||
        //                (!string.IsNullOrEmpty(p.Description) && p.Description.Contains(searchFilter, StringComparison.OrdinalIgnoreCase))
        //            ).ToList();
        //    }

        //    model.TotalProducts = model.Products.Count();

        //    model.Products = sortDirection.ToLower() == "asc"
        //    ? model.Products.OrderBy(e => EF.Property<object>(e, sortBy))
        //    : model.Products.OrderByDescending(e => EF.Property<object>(e, sortBy));

        //    model.Products = model.Products
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    return model;
        //}

        public async Task<FetchProductsModel> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchProductsModel model = new FetchProductsModel();

            IQueryable<Product> productsQuery = _db.products.AsQueryable();

            model.TotalProducts = await productsQuery.CountAsync();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                productsQuery = productsQuery.Where(p =>
                    (p.Name != null && p.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase)) ||
                    (p.Description != null && p.Description.Contains(searchFilter, StringComparison.OrdinalIgnoreCase))
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

            model.Products = productsList;

            return model;

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
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
