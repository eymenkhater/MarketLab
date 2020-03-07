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
    public class ProductResourceRepository : MarketLabContextRepository<ProductResource>, IProductResourceRepository
    {
        #region CTOR
        public ProductResourceRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region List Async
        public async Task<List<ProductResource>> ListAsync()
        {
            return await _dbContext.ProductResources.Where(q => !q.IsDeleted).ToListAsync();
        }
        #endregion

        #region GetAsync
        public async Task<ProductResource> GetAsync(int id)
        {
            return await _dbContext.ProductResources.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        #endregion
    }
}