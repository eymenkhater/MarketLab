using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IProductRepository : ISelectableRepository<Product>, IRepository<Product>
    {
        Task<List<Product>> ListAsync(int resourceId);
        Task<List<Product>> ListSearchAsync(string keyword);
        Task<Product> GetAsync(string name);
    }
}