using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Infra.Data.EFCore.BulkRepositories
{
    public class BulkBrandRepository : IBulkBrandRepository
    {
        #region Fields
        private readonly IUnitOfWorkRepository<Brand> _unitOfWorkRepository;
        #endregion

        #region CTOR
        public BulkBrandRepository(IUnitOfWorkRepository<Brand> unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        #endregion
        public async Task<bool> BulkInsertAsync(IEnumerable<Brand> Brands)
        {
            foreach (var item in Brands)
                await _unitOfWorkRepository.CreateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }

        public async Task<bool> BulkUpdateAsync(IEnumerable<Brand> Brands)
        {
            foreach (var item in Brands)
                await _unitOfWorkRepository.UpdateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }
    }
}