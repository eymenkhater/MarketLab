using MarketLab.Domain.Listings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.Property(q => q.IdentifierUrl).IsRequired();
            BaseConfiguration.Configure<Listing>(builder);
        }
    }
}