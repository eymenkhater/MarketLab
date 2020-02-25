using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface IMarketLabDbContext : IDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDimension> ProductDimensions { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductResource> ProductResources { get; set; }
        DbSet<Resource> Resources { get; set; }
    }
}