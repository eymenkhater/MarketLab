using MarketLab.Domain.Core.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories.Base
{
    public class BaseRepository : DbContext
    {
        #region Fields
        protected readonly IDbContext _dbContext;
        #endregion

        #region CTOR
        public BaseRepository(IDbContext dbContext) => this._dbContext = dbContext;
        #endregion
    }
}