using MarketLab.Application.Core.Interfaces.Identity;
using Microsoft.AspNetCore.Http;

namespace MarketLab.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        #region Fields
        // private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        public CurrentUserService()
        {
            // _httpContextAccessor = httpContextAccessor;
        }
        public int Id { get; set; }
        public string Username { get; set; }
    }
}