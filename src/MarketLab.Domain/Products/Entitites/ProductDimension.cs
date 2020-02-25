using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    public class ProductDimension : EntityBase
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Mass { get; set; } // KEG VALUE OR ML VALUE
        public string Type { get; set; } //KG OR ML
    }
}