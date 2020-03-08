using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;
using MarketLab.Domain.ShoppingLists.Entities;
using MarketLab.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Persistence
{
    public class MarketLabDbContext : DbContext, IMarketLabDbContext
    {
        #region CTOR
        public MarketLabDbContext(DbContextOptions<MarketLabDbContext> options) : base(options) { }
        #endregion

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductResource> ProductResources { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketLabDbContext).Assembly);

    }
}