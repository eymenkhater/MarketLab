using System.Collections.Generic;
using MarketLab.Application.Core.Dtos;

namespace MarketLab.Application.Listings.Models.Responses
{
    public class FeaturedListingsResponse : ProductDto
    {
        public ListingDto Listing { get; set; }
        public ResourceDto Resource { get; set; }
        public ProductImageDto ProductImage { get; set; }
    }
}