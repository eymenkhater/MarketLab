using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Resources.Entities;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class ResourceRepository : MarketLabContextRepository<Resource>, IResourceRepository
    {
        #region CTOR
        public ResourceRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
        public async Task<List<Resource>> ListAsync()
        {
            return await _dbContext.Resources.Where(q => !q.IsDeleted).ToListAsync();
        }

        #region GetAsync

        public async Task<Resource> GetAsync(int id)
        {
            return await _dbContext.Resources.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        public async Task<Resource> GetAsync(string name)
        {
            return await _dbContext.Resources.FirstOrDefaultAsync(q => q.Name == name && !q.IsDeleted);
        }
        #endregion
    }
}