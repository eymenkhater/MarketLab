using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.BulkRepositories
{
    public interface IBulkProductRepository
    {
        Task<bool> BulkInsertAsync(IEnumerable<Product> products);
        Task<bool> BulkUpdateAsync(IEnumerable<Product> products);
    }
}