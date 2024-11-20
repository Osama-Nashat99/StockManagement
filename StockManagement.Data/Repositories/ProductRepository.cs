using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;

namespace StockManagement.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<FetchProductsModel> FetchAsync(string name, string description, int pageNumber = 1, int pageSize = 10)
        {
            FetchProductsModel model = new FetchProductsModel();

            model.Products = await _db.products.AsNoTracking().ToListAsync();

            if (!string.IsNullOrEmpty(name))
            {
                model.Products = model.Products.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(description))
            {
                model.Products = model.Products.Where(p => !string.IsNullOrEmpty(p.Description) && p.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            model.TotalProducts = model.Products.Count();

            model.Products = model.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

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
