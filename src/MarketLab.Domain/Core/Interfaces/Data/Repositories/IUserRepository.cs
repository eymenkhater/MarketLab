using System.Threading.Tasks;
using MarketLab.Domain.Users.Entities;

namespace MarketLab.Domain.Core.Interfaces.Data.Repositories
{
    public interface IUserRepository : ISelectableRepository<User>, IRepository<User>
    {
        Task<User> GetAsync(string username);

    }
}