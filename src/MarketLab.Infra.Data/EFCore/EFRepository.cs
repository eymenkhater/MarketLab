using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore
{
    public class EFRepository<T> : BaseRepository, IRepository<T> where T : EntityBase
    {

        #region CTOR
        public EFRepository(IDbContext dbContext) : base(dbContext) { }
        #endregion

        #region List Async
        // public async Task<IQueryable<T>> ListAsync() => (await _dbContext.Set<T>().AsNoTracking().ToListAsync()).AsQueryable();
        #endregion

        #region Get By Id Async
        public virtual async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        #endregion

        #region Create Async
        public virtual async Task<bool> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        #endregion

        #region Update Async
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
        #endregion

        #region Delete Async
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        #endregion

    }
}