namespace MarketLab.Application.Core.Queries.Primitives
{
    public class PagingQuery
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int Total { get; set; }
    }
}