using System.Collections.Generic;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Queries.Primitives;
using MarketLab.Application.Products.Dtos;

namespace MarketLab.Application.Products.Models.Responses
{
    public class SearchProductResponse : DataQuery
    {
        public SearchProductResponse(List<ProductSearchDto> products)
        {
            Products = products;
        }
        public List<ProductSearchDto> Products { get; set; }
    }
}