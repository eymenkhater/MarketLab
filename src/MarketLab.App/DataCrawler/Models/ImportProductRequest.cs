using System.Collections.Generic;

namespace DataCrawler.Models
{
    public class ImportProductRequest
    {
        public SaveBrandRequest Brand { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<SaveProductImageRequest> ProductImages { get; set; }
        public SaveProductResourceRequest ProductResource { get; set; }
    }
}