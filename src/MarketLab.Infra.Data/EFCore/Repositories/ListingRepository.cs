using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Constants;
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

        public async Task<List<Listing>> ListAsync(int productId)
        {
            var listings = await _dbContext.Listings
                                    .Include(q => q.Resource)
                                    .Include(q => q.ShoppingListItem)
                                    .Where(q => q.ProductId == productId
                                    && !q.IsDeleted
                                    && !q.Resource.IsDeleted).ToListAsync();
            return listings;
        }

        public async Task<List<Listing>> ListFeaturedAsync()
        {
            return await _dbContext.Listings
                        .Include(q => q.Product)
                        .Include(q => q.Product.ProductImages)
                        .Include(q => q.Resource)
                        .Where(q => q.Status == StatusBase.Active
                        && !q.IsDeleted
                        && !q.Product.IsDeleted
                        && !q.Resource.IsDeleted
                        && q.Price > 0).OrderByDescending(q => q.Price).Take(50).ToListAsync();
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