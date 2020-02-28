namespace MarketLab.Application.Products.Models.Requests
{
    public class CreateProductRequest : SaveProductRequest
    {
        public int BrandId { get; set; }
    }
}