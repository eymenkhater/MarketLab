using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Infra.Data.EFCore.BulkRepositories
{
    public class BulkProductRepository : IBulkProductRepository
    {
        #region Fields
        private readonly IUnitOfWorkRepository<Product> _unitOfWorkRepository;
        #endregion

        #region CTOR
        public BulkProductRepository(IUnitOfWorkRepository<Product> unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        #endregion
        public async Task<bool> BulkInsertAsync(IEnumerable<Product> products)
        {
            foreach (var item in products)
                await _unitOfWorkRepository.CreateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }

        public async Task<bool> BulkUpdateAsync(IEnumerable<Product> products)
        {
            foreach (var item in products)
                await _unitOfWorkRepository.UpdateAsync(item);

            return await _unitOfWorkRepository.SaveChangesAsync();
        }
    }
}