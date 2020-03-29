namespace DataCrawler.Models
{
    public class SaveListingRequest
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string IdentifierUrl { get; set; }
    }
}