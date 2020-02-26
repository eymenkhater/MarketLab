using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IProductRepository : ISelectableRepository<Product>, IRepository<Product>
    {
        Task<Product> GetAsync(string name);
    }
}