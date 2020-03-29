namespace MarketLab.Application.Core.Dtos
{
    public class ListingDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string IdentifierUrl { get; set; }
    }
}