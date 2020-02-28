using MarketLab.Application.Core.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.API.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketLabController : ControllerBase
    {
        #region Fields
        protected ICurrentUserService CurrentUser;
        #endregion
        protected ICurrentUserService _currentUser => CurrentUser ?? HttpContext.RequestServices.GetService<ICurrentUserService>();
    }
}
