using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.BulkRepositories
{
    public interface IBulkBrandRepository
    {
        Task<bool> BulkInsertAsync(IEnumerable<Brand> brands);
        Task<bool> BulkUpdateAsync(IEnumerable<Brand> brands);
    }
}