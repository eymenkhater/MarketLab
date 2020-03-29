using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Users.Entities;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class UserRepository : MarketLabContextRepository<User>, IUserRepository
    {
        #region CTOR
        public UserRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
        public async Task<List<User>> ListAsync()
        {
            return await _dbContext.Users.Where(q => !q.IsDeleted).ToListAsync();
        }

        #region GetAsync

        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        public async Task<User> GetAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(q => q.Username.ToLower() == username && !q.IsDeleted);
        }
        #endregion
    }
}