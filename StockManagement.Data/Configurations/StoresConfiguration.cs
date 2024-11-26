using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.Configurations
{
    public class StoresConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).HasMaxLength(200).IsRequired(true);

            builder.HasOne(s => s.StoreKeeper)
                .WithOne()
                .HasForeignKey<Store>(s => s.StoreKeeperId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.CreatedDate).HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.CreatedBy).HasMaxLength(200).IsRequired(false);

            builder.Property(s => s.ModifiedDate).IsRequired(false);

            builder.Property(s => s.ModifiedBy).HasMaxLength(200).IsRequired(false);

            builder.ToTable("Stores");

            LoadStores(builder);

        }

        private void LoadStores(EntityTypeBuilder<Store> builder) 
        {
            builder.HasData(
                new Store() { Id = 1, Name = "Store 1", StoreKeeperId = 1, CreatedBy = "admin"},
                new Store() { Id = 2, Name = "Store 2", StoreKeeperId = 2, CreatedBy ="admin"}
            );
        }
    }
}
