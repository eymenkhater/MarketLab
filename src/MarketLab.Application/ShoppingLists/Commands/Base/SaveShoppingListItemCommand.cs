namespace MarketLab.Application.ShoppingLists.Commands.Base
{
    public class SaveShoppingListItemCommand
    {
        public int ListingId { get; set; }
        public int Quantity { get; set; }
    }
}