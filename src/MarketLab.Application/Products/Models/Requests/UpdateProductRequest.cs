namespace MarketLab.Application.Products.Models.Requests
{
    public class UpdateProductRequest : SaveProductRequest
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
    }
}