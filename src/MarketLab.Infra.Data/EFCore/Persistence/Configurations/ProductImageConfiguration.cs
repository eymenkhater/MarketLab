using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            BaseConfiguration.Configure<ProductImage>(builder);
            builder.Property(q => q.ImagePath).IsRequired().HasMaxLength(1000);
        }
    }
}