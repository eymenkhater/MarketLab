using MarketLab.Domain.ShoppingLists.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.Property(q => q.UserId).IsRequired();
            builder.Property(q => q.Name).HasMaxLength(30).IsRequired();
            BaseConfiguration.Configure<ShoppingList>(builder);

        }
    }
}