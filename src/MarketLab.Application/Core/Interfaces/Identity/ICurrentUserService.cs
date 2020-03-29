using MarketLab.Domain.Users.Entities;

namespace MarketLab.Application.Core.Interfaces.Identity
{
    public interface ICurrentUserService
    {
        User User { get; set; }
    }
}