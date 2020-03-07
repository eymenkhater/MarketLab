using System.Collections.Generic;
using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    public class ProductResource : EntityBase
    {
        public int ProductId { get; set; }
        public int ResourceId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string IdentifierUrl { get; set; }

        public Product Product { get; set; }
    }
}