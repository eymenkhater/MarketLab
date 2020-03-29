using System.Collections.Generic;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Listings.Models.Responses;
using MarketLab.Application.Products.Models.Responses;

namespace MarketLab.Application.Listings.Queries.GetFeaturedListings
{
    public class GetFeaturedListingsQuery : ProductDto, IQuery<List<FeaturedListingsResponse>>
    {
        public ListingDto Listing { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public ResourceDto ResourceDto { get; set; }
    }
}