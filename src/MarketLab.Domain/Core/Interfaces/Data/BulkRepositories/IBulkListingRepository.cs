using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Listings.Entities;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.BulkRepositories
{
    public interface IBulkListingRepository
    {
        Task<bool> BulkInsertAsync(IEnumerable<Listing> listings);
        Task<bool> BulkUpdateAsync(IEnumerable<Listing> listings);
    }
}