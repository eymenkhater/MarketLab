using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Products.Entitites
{
    [Table("Products")]
    public class Product : EntityBase
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            ProductResources = new HashSet<ProductResource>();
            BrandId = 1;
        }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #region Relations
        public Brand Brand { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductResource> ProductResources { get; set; }

        #endregion
    }
}