using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Infra.Data.EFCore.Repositories.Base;

namespace MarketLab.Infra.Data.EFCore
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        #region CTOR
        public UnitOfWork(IDbContext dbContext) : base(dbContext) { }
        #endregion

        #region Save Changes Async
        public async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;
        #endregion
    }
}