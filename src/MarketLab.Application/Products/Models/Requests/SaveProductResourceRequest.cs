namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductResourceRequest
    {
        public int ResourceId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}