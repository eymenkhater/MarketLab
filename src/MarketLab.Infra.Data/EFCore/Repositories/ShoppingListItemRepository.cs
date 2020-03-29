using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.ShoppingLists.Entities;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Repositories
{
    public class ShoppingListItemRepository : MarketLabContextRepository<ShoppingListItem>, IShoppingListItemRepository
    {
        #region CTOR
        public ShoppingListItemRepository(IMarketLabDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
        public async Task<List<ShoppingListItem>> ListAsync()
        {
            return await _dbContext.ShoppingListItems.Where(q => !q.IsDeleted).ToListAsync();
        }

        #region GetAsync

        public async Task<ShoppingListItem> GetAsync(int id)
        {
            return await _dbContext.ShoppingListItems.FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);
        }
        #endregion
    }
}