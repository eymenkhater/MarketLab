using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Listings.Entities;

namespace MarketLab.Infra.Data.EFCore.BulkRepositories
{
    public class BulkListingRepository : IBulkListingRepository
    {
        #region Fields
        private readonly IUnitOfWorkRepository<Listing> _unitOfWorkRepository;
        #endregion

        #region CTOR
        public BulkListingRepository(IUnitOfWorkRepository<Listing> unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        #endregion
        public async Task<bool> BulkInsertAsync(IEnumerable<Listing> listings)
        {
            foreach (var item in listings)
                await _unitOfWorkRepository.CreateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }

        public async Task<bool> BulkUpdateAsync(IEnumerable<Listing> listings)
        {
            foreach (var item in listings)
                await _unitOfWorkRepository.UpdateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }
    }
}