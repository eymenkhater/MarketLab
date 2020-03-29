using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Queries.Primitives;
using MarketLab.Application.Products.Models.Responses;

namespace MarketLab.Application.Products.Queries.SearchProduct
{
    public class SearchProductQuery : DataQuery, IQuery<SearchProductResponse>
    {
    }
}