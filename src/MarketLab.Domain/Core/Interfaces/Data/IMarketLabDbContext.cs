using MarketLab.Domain.Listings.Entities;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;
using MarketLab.Domain.SearchLogs.Entities;
using MarketLab.Domain.Sliders.Entities;
using MarketLab.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface IMarketLabDbContext : IDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Listing> Listings { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<SearchLog> SearchLogs { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<User> Users { get; set; }

    }
}