using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;
using MarketLab.Domain.ShoppingLists.Entities;

namespace MarketLab.Domain.Listings.Entities
{
    public class Listing : EntityBase
    {
        public int ProductId { get; set; }
        public int ResourceId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string IdentifierUrl { get; set; }
        public Product Product { get; set; }
        public Resource Resource { get; set; }
        public ShoppingListItem ShoppingListItem { get; set; }
    }
}