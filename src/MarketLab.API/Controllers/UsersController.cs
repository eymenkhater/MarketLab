using MarketLab.API.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : MarketLabController
    {
        #region Fields
        private readonly ILogger<UsersController> _logger;
        #endregion

        #region CTOR
        public UsersController(
            ILogger<UsersController> logger
            )
        {
            _logger = logger;
        }
        #endregion
    }
}
