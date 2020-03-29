using System.Collections.Generic;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Listings.Models.Responses;

namespace MarketLab.Application.Listings.Queries.GetSelectedProductListings
{
    public class GetSelectedProductListingsQuery : IQuery<List<SelectedProductListingsResponse>>
    {
        public GetSelectedProductListingsQuery(int productId)
        {
            this.ProductId = productId;

        }
        public int ProductId { get; set; }
    }
}