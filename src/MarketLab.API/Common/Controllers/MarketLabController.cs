using MarketLab.Application.Core.Interfaces.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.API.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketLabController : ControllerBase
    {
        #region Fields
        protected IMediator Mediator;
        protected ICurrentUserService CurrentUser;
        #endregion

        protected IMediator _mediator => Mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUserService _currentUser => CurrentUser ?? HttpContext.RequestServices.GetService<ICurrentUserService>();
    }
}
