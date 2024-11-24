using Microsoft.AspNetCore.Identity;
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
            builder.Property("FirstName").HasMaxLength(100).IsRequired(false);
            builder.Property("LastName").HasMaxLength(100).IsRequired(false);
            builder.Property("Password").HasMaxLength(500).IsRequired(true);
            builder.Property("Role").HasMaxLength(100).IsRequired(true);
            builder.Property("IsFirstLogin").HasDefaultValue(true);
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
            PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

            User adminUser = new User { Id = 1, Username = "admin", FirstName = "admin", LastName = "admin", Password = "admin123", Role = Roles.Admin, IsFirstLogin = false, CreatedBy = "admin" };
            adminUser.Password = _passwordHasher.HashPassword(adminUser, adminUser.Password);

            User normalUser = new User { Id = 2, Username = "user", FirstName = "user", LastName = "user", Password = "user123", Role = Roles.User, IsFirstLogin = false, CreatedBy = "admin" };
            normalUser.Password = _passwordHasher.HashPassword(normalUser, normalUser.Password);

            builder.HasData(
               adminUser, normalUser
            );
        }
    }
}
