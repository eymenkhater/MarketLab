using System.Collections.Generic;

namespace MarketLab.Application.Products.Models.Requests
{
    public class SaveProductRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<SaveProductImageRequest> ProductImages { get; set; }
        public SaveProductResourceRequest ProductResource { get; set; }

    }
}