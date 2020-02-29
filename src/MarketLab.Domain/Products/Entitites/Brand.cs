using System.Collections.Generic;
using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    public class Brand : EntityBase
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}