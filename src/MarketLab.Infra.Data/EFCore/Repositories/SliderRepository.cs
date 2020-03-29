using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Constants;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Sliders.Entities;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class SliderRepository : MarketLabContextRepository<Slider>, ISliderRepository
    {
        #region CTOR
        public SliderRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        public async Task<List<Slider>> ListAsync()
        {
            return await _dbContext.Sliders.Where(q => !q.IsDeleted && q.Status == StatusBase.Active).OrderBy(q => q.UpdatedAt).ToListAsync();
        }

        public Task<Slider> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}