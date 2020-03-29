namespace MarketLab.Application.Core.Dtos
{
    public class ShoppingListItemDto
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public int ListingId { get; set; }
        public int Quantity { get; set; }
    }
}