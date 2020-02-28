using System.Collections.Generic;

namespace MarketLab.Application.Products.Models.Requests
{
    public class ImportProductRequest : SaveProductRequest
    {
        public string BrandName { get; set; }
    }
}