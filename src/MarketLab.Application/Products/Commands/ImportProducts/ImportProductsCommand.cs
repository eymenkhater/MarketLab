using System.Collections.Generic;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Products.Models.Requests;

namespace MarketLab.Application.Products.Commands.ImportProducts
{
    public class ImportProductsCommand : ICommand<bool>
    {
        public ImportProductsCommand() { }
        public ImportProductsCommand(int resourceId, List<ImportProductRequest> products)
        {
            this.ResourceId = resourceId;
            this.Products = products;

        }
        public int ResourceId { get; set; }
        public List<ImportProductRequest> Products { get; set; }

    }
}