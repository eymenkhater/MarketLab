using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    public class ProductResource : EntityBase
    {
        public int ProductId { get; set; }
        public int ResourceId { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}