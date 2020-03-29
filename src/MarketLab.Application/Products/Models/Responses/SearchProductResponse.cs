using System.Collections.Generic;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Queries.Primitives;

namespace MarketLab.Application.Products.Models.Responses
{
    public class SearchProductResponse : DataQuery
    {
        public SearchProductResponse(List<ProductDto> products)
        {
            Products = products;
        }
        public List<ProductDto> Products { get; set; }
    }
}