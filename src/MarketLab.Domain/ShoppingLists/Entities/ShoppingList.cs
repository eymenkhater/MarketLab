using System.Collections.Generic;
using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.ShoppingLists.Entities
{
    public class ShoppingList : EntityBase
    {
        public ShoppingList()
        {
            ShoppingListItems = new HashSet<ShoppingListItem>();
        }
        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}