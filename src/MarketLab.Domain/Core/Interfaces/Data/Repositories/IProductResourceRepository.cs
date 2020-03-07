using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IProductResourceRepository
    {
        Task<List<ProductResource>> ListAsync();
        Task<ProductResource> GetAsync(int id);
    }
}