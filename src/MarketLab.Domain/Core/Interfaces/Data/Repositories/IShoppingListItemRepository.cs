using MarketLab.Domain.ShoppingLists.Entities;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IShoppingListItemRepository : ISelectableRepository<ShoppingListItem>, IRepository<ShoppingListItem>
    {

    }
}