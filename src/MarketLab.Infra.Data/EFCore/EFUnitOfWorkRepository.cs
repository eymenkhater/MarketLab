using System.Threading.Tasks;
using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Core.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore
{
    public class EFUnitOfWorkRepository<T> : UnitOfWork, IUnitOfWorkRepository<T> where T : EntityBase
    {
        #region CTOR
        public EFUnitOfWorkRepository(IDbContext dbContext) : base(dbContext) { }
        #endregion

        #region Create Async
        public async Task CreateAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        #endregion

        #region Update Async
        public async Task UpdateAsync(T entity) => await Task.FromResult(_dbContext.Entry(entity).State = EntityState.Modified);
        #endregion

        #region Delete Async
        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(_dbContext.Set<T>().Remove(entity));
        }
        #endregion
    }
}