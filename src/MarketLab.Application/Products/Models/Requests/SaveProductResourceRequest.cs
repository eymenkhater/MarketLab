namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductResourceRequest
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}