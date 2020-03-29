using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Sliders.Entities;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface ISliderRepository : ISelectableRepository<Slider>, IRepository<Slider>
    {
    }
}