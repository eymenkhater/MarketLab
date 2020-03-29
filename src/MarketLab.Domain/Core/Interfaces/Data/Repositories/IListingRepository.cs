using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Listings.Entities;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IListingRepository : ISelectableRepository<Listing>
    {
        Task<List<Listing>> ListAsync(int resourceId);
    }
}