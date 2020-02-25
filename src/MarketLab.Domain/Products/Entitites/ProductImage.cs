using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    public class ProductImage : EntityBase
    {
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}