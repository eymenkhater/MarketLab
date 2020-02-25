using System.Threading.Tasks;

namespace MarketLab.Domain.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}