using System.Collections.Generic;

namespace MarketLab.Application.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public BrandDto Brand { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
        public ICollection<ListingDto> Listings { get; set; }
    }
}