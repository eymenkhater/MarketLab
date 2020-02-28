namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductResourceRequest
    {
        public int ResourceId { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}