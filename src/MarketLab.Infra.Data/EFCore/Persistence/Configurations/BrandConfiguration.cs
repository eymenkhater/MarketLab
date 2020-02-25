using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            BaseConfiguration.Configure<Brand>(builder);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(200);

        }
    }
}