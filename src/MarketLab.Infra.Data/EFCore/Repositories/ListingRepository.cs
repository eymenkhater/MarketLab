using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Listings.Entities;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class ListingRepository : MarketLabContextRepository<Listing>, IListingRepository
    {
        #region CTOR
        public ListingRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region List Async
        public async Task<List<Listing>> ListAsync()
        {
            return await _dbContext.Listings.Where(q => !q.IsDeleted).ToListAsync();
        }

        public async Task<List<Listing>> ListAsync(int resourceId)
        {
            return await _dbContext.Listings
                                    .Include(q => q.Product)
                                    .Where(q => q.ResourceId == resourceId && !q.IsDeleted && !q.Product.IsDeleted).ToListAsync();
        }
        #endregion

        #region GetAsync
        public async Task<Listing> GetAsync(int id)
        {
            return await _dbContext.Listings.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        #endregion
    }
}