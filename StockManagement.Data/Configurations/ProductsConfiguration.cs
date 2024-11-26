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

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired(true);

            builder.Property(p => p.CategoryId).IsRequired(true);

            builder.Property(p => p.Price).HasColumnType("decimal").HasPrecision(10, 2);

            builder.Property(p => p.SerialNumber).HasMaxLength(500).IsRequired(false);

            builder.HasIndex(p => p.SerialNumber).IsUnique();

            builder.Property(p => p.Status).IsRequired(true);

            builder.Property(p => p.IssuedFor).HasMaxLength(200).IsRequired(false);

            builder.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.CreatedBy).HasMaxLength(200).IsRequired(false);

            builder.Property(p => p.ModifiedDate).IsRequired(false);

            builder.Property(p => p.ModifiedBy).HasMaxLength(200).IsRequired(false);

            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Store).WithMany(s => s.Products).HasForeignKey(p => p.StoreId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Products");

            LoadProducts(builder);
        }


        private void LoadProducts(EntityTypeBuilder<Product> builder) { 
            builder.HasData(
                    new Product() { Id = 1, Name = "Smartphone XYZ", Description = "A high-end smartphone with amazing features", Price = 799.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 2, Name = "Stylish Leather Jacket", Description = "A premium leather jacket for winter", Price = 120.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Clothes.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Out_Stock, StoreId = 2 },
                    new Product() { Id = 3, Name = "Bluetooth Headphones", Description = "Noise-canceling wireless headphones", Price = 150.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 4, Name = "Winter Jacket", Description = "A cozy winter jacket to keep you warm", Price = 80.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Clothes.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Damaged, StoreId = 1 },
                    new Product() { Id = 5, Name = "Smart Watch", Description = "A smartwatch with fitness tracking and notifications", Price = 200.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 2 },
                    new Product() { Id = 6, Name = "LED TV", Description = "Ultra HD LED TV with smart features", Price = 500.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 7, Name = "Electric Kettle", Description = "Fast boiling electric kettle for quick tea or coffee", Price = 30.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Damaged, StoreId = 2 },
                    new Product() { Id = 8, Name = "Refrigerator", Description = "Energy-efficient fridge with large capacity", Price = 800.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 2 },
                    new Product() { Id = 9, Name = "Portable Speaker", Description = "Water-resistant portable Bluetooth speaker", Price = 90.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 10, Name = "Air Fryer", Description = "Healthy cooking with this modern air fryer", Price = 150.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Out_Stock, StoreId = 1 },
                    new Product() { Id = 11, Name = "Electric Toothbrush", Description = "Sonic electric toothbrush for cleaner teeth", Price = 60.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 12, Name = "Digital Camera", Description = "High-quality digital camera for photography enthusiasts", Price = 400.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 2 },
                    new Product() { Id = 13, Name = "Gaming Mouse", Description = "Ergonomic gaming mouse with customizable buttons", Price = 50.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Issued, StoreId = 1, IssuedFor = "user" },
                    new Product() { Id = 14, Name = "LED Desk Lamp", Description = "Adjustable desk lamp with LED lighting", Price = 40.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 15, Name = "Car Phone Mount", Description = "Magnetic phone mount for easy car navigation", Price = 20.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Cars.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 16, Name = "Camping Tent", Description = "Spacious 4-person camping tent with waterproof design", Price = 120.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Cars.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Damaged, StoreId = 2 },
                    new Product() { Id = 17, Name = "Smart Thermostat", Description = "Wi-Fi enabled smart thermostat for energy savings", Price = 250.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Damaged, StoreId = 2 },
                    new Product() { Id = 18, Name = "Portable Charger", Description = "High-capacity portable power bank for smartphones", Price = 40.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Out_Stock, StoreId = 1 },
                    new Product() { Id = 19, Name = "Laptop Backpack", Description = "Durable and spacious backpack for laptops and accessories", Price = 40.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Clothes.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Issued, StoreId = 2, IssuedFor = "user" },
                    new Product() { Id = 20, Name = "Wall Clock", Description = "Sleek modern wall clock with a minimal design", Price = 25.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Clothes.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 21, Name = "Hair Dryer", Description = "Professional blow dryer with multiple heat settings", Price = 70.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 2 },
                    new Product() { Id = 22, Name = "Portable Blender", Description = "Blend your smoothies on the go with this portable blender", Price = 45.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Issued, StoreId = 2, IssuedFor = "user" },
                    new Product() { Id = 23, Name = "Camping Stove", Description = "Portable camping stove for outdoor cooking", Price = 70.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Cars.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 24, Name = "Fitness Tracker", Description = "Wearable fitness tracker to monitor daily activities", Price = 130.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Electronics.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 },
                    new Product() { Id = 25, Name = "Gaming Chair", Description = "Ergonomic gaming chair with adjustable armrests", Price = 180.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Clothes.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.Issued, StoreId = 1, IssuedFor = "user" },
                    new Product() { Id = 26, Name = "Solar Charger", Description = "Eco-friendly solar charger for your devices", Price = 35.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Cars.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 2 },
                    new Product() { Id = 27, Name = "Air Purifier", Description = "Home air purifier with HEPA filter for cleaner air", Price = 150.00m, SerialNumber = Guid.NewGuid().ToString(), CategoryId = Categories.Kitchen.GetHashCode(), CreatedBy = "admin", Status = ProductStatus.In_Stock, StoreId = 1 }
            );
        }
    }
}
