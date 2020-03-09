using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Products.Models.Responses;

namespace MarketLab.Application.Products.Queries.SearchProduct
{
    public class SearchProductQuery : IQuery<SearchProductResponse>
    {
        public SearchProductQuery(string keyword)
        {
            Keyword = keyword;
        }

        public string Keyword { get; set; }
    }
}