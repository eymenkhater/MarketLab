using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;
using MarketLab.Domain.Resources.Entities;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IResourceRepository : ISelectableRepository<Resource>, IRepository<Resource>
    {
        Task<Resource> GetAsync(string name);
    }
}