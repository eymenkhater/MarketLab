using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.SearchLogs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class SearchLogConfiguration : IEntityTypeConfiguration<SearchLog>
    {
        public void Configure(EntityTypeBuilder<SearchLog> builder)
        {
            BaseConfiguration.Configure<SearchLog>(builder);
            builder.Property(q => q.Keywod).IsRequired().HasMaxLength(200);

        }
    }
}