using MarketLab.Domain.Core.Entities;
using MarketLab.Domain.Resources.Constants;

namespace MarketLab.Domain.Resources.Entities
{
    public class Resource : EntityBase
    {
        public int Type { get; set; } = ResourceType.Supermarket;
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}