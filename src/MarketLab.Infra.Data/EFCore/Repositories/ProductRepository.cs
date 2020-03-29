using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class ProductRepository : MarketLabContextRepository<Product>, IProductRepository
    {
        #region CTOR
        public ProductRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region List Async
        public async Task<List<Product>> ListAsync()
        {
            return (await _dbContext.Products.Include(q => q.Listings)
                                            .Where(q => q.Listings.Any(x => !x.IsDeleted) && !q.IsDeleted).ToListAsync());
        }
        public async Task<List<Product>> ListAsync(int resourceId)
        {
            return await _dbContext.Products.Include(q => q.Listings
                                                .Where(q => q.ResourceId == resourceId && !q.IsDeleted))
                                            .Where(q => !q.IsDeleted).ToListAsync();
        }
        public async Task<List<Product>> ListSearchAsync()
        {
            return (await _dbContext.Products.Include(q => q.Listings)
                                            .Include("Listings.Resource")
                                            .Include(q => q.ProductImages)
                                            .Where(q => q.Listings.Any(x => !x.IsDeleted)
                                            && q.ProductImages.Any(q => !q.IsDeleted)
                                            && !q.IsDeleted).ToListAsync());
        }

        #endregion

        #region GetAsync
        public async Task<Product> GetAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        public async Task<Product> GetAsync(string name)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(q => q.Name == name && !q.IsDeleted);
        }
        #endregion
    }
}