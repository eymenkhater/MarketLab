using System.Linq;
using System.Threading.Tasks;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface IRepository<T>
        {
            Task<IQueryable<T>> ListAsync();
            Task<T> GetByIdAsync(int id);
            Task<bool> CreateAsync(T entity);
            Task<bool> UpdateAsync(T entity);
            Task<bool> DeleteAsync(T entity);
        }
}