using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.SearchLogs.Entities;
using MarketLab.Infra.Data.EFCore.Repositories.Base;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class SearchLogRepository : MarketLabContextRepository<SearchLog>, ISearchLogRepository
    {
        #region CTOR
        public SearchLogRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}