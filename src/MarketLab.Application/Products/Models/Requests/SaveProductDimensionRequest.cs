namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductDimensionRequest
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Mass { get; set; }
        public string Type { get; set; }
    }
}