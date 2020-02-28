using System.Collections.Generic;

namespace MarketLab.Application.Products.Models.Requests
{
    public class ImportProductsRequest
    {
        public List<CreateProductRequest> Products { get; set; }
    }
}