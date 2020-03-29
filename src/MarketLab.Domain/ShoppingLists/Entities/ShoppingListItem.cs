using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.ShoppingLists.Entities
{
    public class ShoppingListItem : EntityBase
    {
        public int ShoppingListId { get; set; }
        public int ListingId { get; set; }
        public int Quantity { get; set; }
    }
}