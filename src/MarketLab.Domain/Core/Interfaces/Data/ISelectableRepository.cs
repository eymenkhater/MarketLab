using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface ISelectableRepository<T>
    {
        Task<List<T>> ListAsync();
        Task<T> GetAsync(int id);
    }
}