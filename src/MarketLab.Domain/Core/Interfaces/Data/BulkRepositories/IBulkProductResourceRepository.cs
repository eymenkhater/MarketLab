using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.BulkRepositories
{
    public interface IBulkProductResourceRepository
    {
        Task<bool> BulkInsertAsync(IEnumerable<ProductResource> productResources);
        Task<bool> BulkUpdateAsync(IEnumerable<ProductResource> productResources);
    }
}