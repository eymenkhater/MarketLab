using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Infra.Data.EFCore.BulkRepositories
{
    public class BulkBrandRepository : IBulkBrandRepository
    {
        public Task<bool> BulkInsertAsync(IEnumerable<Brand> brands)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(IEnumerable<Brand> brands)
        {
            throw new System.NotImplementedException();
        }
    }
}