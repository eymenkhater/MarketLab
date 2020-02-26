using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IBrandRepository : ISelectableRepository<Brand>, IRepository<Brand>
    {
        Task<Brand> GetAsync(string name);
    }
}