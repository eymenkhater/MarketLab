using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.ShoppingLists.Commands.Base;

namespace MarketLab.Application.ShoppingLists.Commands.CreateShoppingListItem
{
    public class CreateShoppingListItemCommand : SaveShoppingListItemCommand, ICommand<ShoppingListItemDto>
    {

    }
}