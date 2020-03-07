using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ProductResourceConfiguration : IEntityTypeConfiguration<ProductResource>
    {
        public void Configure(EntityTypeBuilder<ProductResource> builder)
        {
            builder.Property(q => q.IdentifierUrl).IsRequired();
            BaseConfiguration.Configure<ProductResource>(builder);
        }
    }
}