using System.Threading.Tasks;
using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface IUnitOfWorkRepository<T> : IUnitOfWork where T : EntityBase
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}