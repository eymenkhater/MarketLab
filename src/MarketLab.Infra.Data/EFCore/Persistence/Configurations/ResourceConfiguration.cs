using MarketLab.Domain.Resources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            BaseConfiguration.Configure<Resource>(builder);
            builder.Property(q => q.Name).HasMaxLength(200).IsRequired();
        }
    }
}