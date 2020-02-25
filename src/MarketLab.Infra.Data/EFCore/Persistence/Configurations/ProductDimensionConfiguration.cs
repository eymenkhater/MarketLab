using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ProductDimensionConfiguration : IEntityTypeConfiguration<ProductDimension>
    {
        public void Configure(EntityTypeBuilder<ProductDimension> builder)
        {
            BaseConfiguration.Configure<ProductDimension>(builder);
            builder.Property(q => q.Type).IsRequired().HasMaxLength(10);
        }
    }
}