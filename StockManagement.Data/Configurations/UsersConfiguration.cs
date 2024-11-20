using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;

namespace StockManagement.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property("Username").HasMaxLength(100).IsRequired(true);
            builder.Property("Password").HasMaxLength(50).IsRequired(true);
            builder.Property("Role").HasMaxLength(100).IsRequired(true);

            LoadUsers(builder);
        }

        private void LoadUsers(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
            );
        }
    }
}
