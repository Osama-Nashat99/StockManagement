using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(200).IsRequired(true);

            builder.Property("CreatedDate").HasDefaultValueSql("GETDATE()");

            builder.Property("CreatedBy").IsRequired(false);

            builder.Property("ModifiedDate").IsRequired(false);

            builder.Property("ModifiedBy").IsRequired(false);

            builder.ToTable("Categories");

            LoadCategories(builder);
        }

        private void LoadCategories(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Clothes", CreatedBy = "admin" },
                new Category { Id = 2, Name = "Accessories", CreatedBy = "admin" },
                new Category { Id = 3, Name = "Electronics", CreatedBy = "admin" },
                new Category { Id = 4, Name = "Kitchen", CreatedBy = "admin" },
                new Category { Id = 5, Name = "Cars", CreatedBy = "admin" }
            );
        }
    }
}
