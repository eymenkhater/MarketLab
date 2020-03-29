using MarketLab.Application.Core.Dtos;

namespace MarketLab.Application.Listings.Models.Responses
{
    public class SelectedProductListingsResponse : ListingDto
    {
        public ResourceDto Resource { get; set; }
        public ShoppingListItemDto ShoppingListItem { get; set; }
    }
}