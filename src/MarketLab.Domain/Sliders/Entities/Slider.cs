using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Sliders.Entities
{
    public class Slider : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ActionUrl { get; set; }
    }
}