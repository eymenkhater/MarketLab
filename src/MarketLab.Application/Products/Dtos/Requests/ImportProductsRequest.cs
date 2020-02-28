using System.Collections.Generic;

namespace MarketLab.Application.Products.Dtos.Requests
{
    public class ImportProductsRequest
    {
        public List<CreateProductRequest> Products { get; set; }
    }
}