using System.Collections.Generic;
using System.Threading.Tasks;
using MarketLab.Domain.Products.Entitites;

namespace MarketLab.Domain.Products.Services
{
    #region Interface
    public interface IProductCheckerService
    {
        Task<bool> IsNameUnique(string name);
        Task<bool> IsUnique(string name, string code);
        Task<bool> IsUnique(string name, int ignoredId);
        Task<bool> IsUnique(string name, string code, int ignoredId);
        Task<bool> IsUnique(IEnumerable<Product> products, string name, string code, int ignoredId);

    }
    #endregion

    #region Fields
    #endregion
    public class ProductCheckerService : IProductCheckerService
    {
        public Task<bool> IsNameUnique(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUnique(string name, string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUnique(string name, int ignoredId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUnique(string name, string code, int ignoredId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUnique(IEnumerable<Product> products, string name, string code, int ignoredId)
        {
            throw new System.NotImplementedException();
        }
    }

}