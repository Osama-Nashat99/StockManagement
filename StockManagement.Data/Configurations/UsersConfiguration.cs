using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property("Username").HasMaxLength(100).IsRequired(true);
            builder.Property("Password").HasMaxLength(500).IsRequired(true);
            builder.Property("Role").HasMaxLength(100).IsRequired(true);
            builder.Property("CreatedDate").HasDefaultValueSql("GETDATE()");
            builder.Property("CreatedBy").IsRequired(false);
            builder.Property("ModifiedDate").IsRequired(false);
            builder.Property("ModifiedBy").IsRequired(false);
            builder.ToTable("Users");

            builder.HasIndex(u => u.Username).IsUnique();

            LoadUsers(builder);
        }

        private void LoadUsers(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin", CreatedBy = "admin" },
                new User { Id = 2, Username = "user", Password = "user123", Role = "User", CreatedBy = "admin" }
            );
        }
    }
}
