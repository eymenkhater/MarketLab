using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Infra.Data.EFCore.BulkRepositories
{
    public class BulkProductResourceRepository : IBulkProductResourceRepository
    {
        #region Fields
        private readonly IUnitOfWorkRepository<ProductResource> _unitOfWorkRepository;
        #endregion

        #region CTOR
        public BulkProductResourceRepository(IUnitOfWorkRepository<ProductResource> unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        #endregion
        public async Task<bool> BulkInsertAsync(IEnumerable<ProductResource> productResources)
        {
            foreach (var item in productResources)
                await _unitOfWorkRepository.CreateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }

        public async Task<bool> BulkUpdateAsync(IEnumerable<ProductResource> productResources)
        {
            foreach (var item in productResources)
                await _unitOfWorkRepository.UpdateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }
    }
}