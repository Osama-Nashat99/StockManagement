using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;

namespace StockManagement.Data.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property("Name").HasMaxLength(100).IsRequired(true);

            builder.Property("Description").HasMaxLength(500).IsRequired(true);

            builder.Property("Category").HasDefaultValue(Categories.None).IsRequired(true);

            builder.Property("Price").HasColumnType("decimal").HasPrecision(10, 2);

            builder.Property("CreatedAt").HasDefaultValueSql("GETDATE()");

            LoadProducts(builder);
        }


        private void LoadProducts(EntityTypeBuilder<Product> builder) { 
            builder.HasData(
                new Product() { Id = 1, Name = "Waterproof Jacket", Description = "This is a description for the leather waterproof black nice jacket.", Price = 86.56m, Quantity = 5, Category = Categories.Clothes },
                new Product() { Id = 2, Name = "Tui Cross Wallet", Description = "This is a description for the Handmade wallet with this new design.", Price = 26.70m, Quantity = 2, Category = Categories.Accessories }
            );
        }
    }
}
