using MarketLab.Application.Core.Interfaces.Identity;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Users.Entities;
using Microsoft.AspNetCore.Http;

namespace MarketLab.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        public CurrentUserService(
            IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _httpContextAccessor = httpContextAccessor;
            User = userRepository.GetAsync(1).Result;
        }

        public User User { get; set; }

    }
}