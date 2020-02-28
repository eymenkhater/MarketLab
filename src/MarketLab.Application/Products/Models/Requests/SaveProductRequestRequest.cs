using System.Collections.Generic;

namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductRequest
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public SaveProductDimensionRequest ProductDimension { get; set; }
        public List<SaveProductImageRequest> ProductImages { get; set; }
        public SaveProductResourceRequest ProductResource { get; set; }

    }
}