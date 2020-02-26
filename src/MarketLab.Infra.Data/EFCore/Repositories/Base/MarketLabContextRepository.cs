using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Core.Interfaces.Data;

namespace MarketLab.Infra.Data.EFCore.Repositories.Base
{
    public class MarketLabContextRepository<T> : EFRepository<T> where T : EntityBase
    {
        #region Fields
        protected new IMarketLabDbContext _dbContext;
        #endregion

        #region CTOR
        public MarketLabContextRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
    }
}