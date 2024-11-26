using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;

namespace StockManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        public DbSet<Store> stores { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<User> users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);            
        }
    }
}
