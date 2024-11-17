using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;

namespace StockManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);            
        }
    }
}
