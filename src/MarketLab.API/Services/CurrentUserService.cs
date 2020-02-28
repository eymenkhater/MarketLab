using MarketLab.Application.Core.Interfaces.Identity;

namespace MarketLab.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}