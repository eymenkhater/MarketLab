namespace MarketLab.Application.Core.Queries.Primitives
{
    public class SearchingQuery
    {
        public string In { get; set; }
        public string Field { get; set; }
        public string Keyword { get; set; }
    }
}