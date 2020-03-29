using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Products.Entitites;

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
    }
}