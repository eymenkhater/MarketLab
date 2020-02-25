using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Resources.Entities
{
    public class Resource : EntityBase
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
    }
}