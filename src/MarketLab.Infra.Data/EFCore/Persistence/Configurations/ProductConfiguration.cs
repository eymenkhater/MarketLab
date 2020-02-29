using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            BaseConfiguration.Configure<Product>(builder);
            builder.Property(q => q.Name).HasMaxLength(500).IsRequired();

            builder.HasOne(q => q.Brand).WithMany(q => q.Products)
                    .HasForeignKey(q => q.BrandId)
                    .OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}