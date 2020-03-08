using MarketLab.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(q => q.Username).HasMaxLength(15).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(256).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(320).IsRequired();
            builder.Property(q => q.Phone).HasMaxLength(10).IsRequired();
            BaseConfiguration.Configure<User>(builder);
        }
    }
}