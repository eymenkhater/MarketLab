using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Products.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories.Base
{
    public class BrandRepository : MarketLabContextRepository<Brand>, IBrandRepository
    {
        #region CTOR
        public BrandRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
        public async Task<List<Brand>> ListAsync()
        {
            return await _dbContext.Brands.Where(q => !q.IsDeleted).ToListAsync();
        }

        #region GetAsync

        public async Task<Brand> GetAsync(int id)
        {
            return await _dbContext.Brands.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        public async Task<Brand> GetAsync(string name)
        {
            return await _dbContext.Brands.FirstOrDefaultAsync(q => q.Name == name && !q.IsDeleted);
        }
        #endregion
    }
}