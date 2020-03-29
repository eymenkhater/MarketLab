using System.Collections.Generic;
using MarketLab.Application.Core.Dtos;

namespace MarketLab.Application.Products.Dtos
{
    public class ProductSearchDto : ProductDto
    {
        public ProductSearchDto()
        {
            ProductImages = new HashSet<ProductImageDto>();
            Resources = new HashSet<ResourceDto>();

        }
        public decimal MinPrice { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
        public ICollection<ResourceDto> Resources { get; set; }
    }
}