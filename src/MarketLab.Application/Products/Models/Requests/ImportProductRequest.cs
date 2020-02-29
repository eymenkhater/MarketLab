using System.Collections.Generic;
using MarketLab.Application.Brands.Models.Requests;

namespace MarketLab.Application.Products.Models.Requests
{
    public class ImportProductRequest : SaveProductRequest
    {
        public SaveBrandRequest Brand { get; set; }
    }
}