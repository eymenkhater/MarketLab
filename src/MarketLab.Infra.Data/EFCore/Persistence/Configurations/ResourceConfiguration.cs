using MarketLab.Domain.Resources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketLab.Infra.Data.EFCore.Persistence.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            var resources = new Resource[]
            {
                new Resource(){ Id = 1, Name ="Kim",BaseUrl ="https://www.kimmarket.com"},
                new Resource(){ Id= 2, Name ="Bim",BaseUrl ="https://www.bim.com.tr/default.aspx"},
                new Resource(){ Id= 3, Name ="A101",BaseUrl ="https://www.a101.com.tr"},
                new Resource(){ Id= 4, Name ="Şok",BaseUrl ="https://www.sokmarket.com.tr/anasayfa"},
                new Resource(){ Id= 5, Name ="Migros",BaseUrl ="https://www.migros.com.tr"},
                new Resource(){ Id= 6, Name ="Carrefoursa",BaseUrl ="https://www.carrefoursa.com/tr"},
                new Resource(){ Id= 7, Name ="Öz Dilek",BaseUrl ="https://www.carrefoursa.com/tr"}
            };

            builder.HasData(resources);

            BaseConfiguration.Configure<Resource>(builder);
            builder.Property(q => q.Name).HasMaxLength(200).IsRequired();
        }
    }
}