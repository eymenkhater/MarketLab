namespace MarketLab.Application.Products.Dtos.Requests
{
    public class UpdateProductRequest : SaveProductRequest
    {
        public int Id { get; set; }
    }
}