using MarketLab.API.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : MarketLabController
    {
        #region Fields
        private readonly ILogger<AccountController> _logger;
        #endregion

        #region CTOR
        public AccountController(
            ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        #endregion
    }
}
