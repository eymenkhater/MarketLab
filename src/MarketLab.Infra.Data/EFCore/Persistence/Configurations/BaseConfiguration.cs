using MarketLab.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public static class BaseConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();
        }
    }
}