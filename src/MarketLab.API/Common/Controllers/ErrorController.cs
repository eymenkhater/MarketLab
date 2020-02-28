using System.Threading.Tasks;
using MarketLab.Application.Core.Constants;
using MarketLab.Application.Core.Interfaces.Identity;
using MarketLab.Application.Core.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ErrorController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region CTOR
        public ErrorController(ILogger<ErrorController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        [HttpGet, HttpPost, HttpPut, HttpDelete]
        public async Task<IActionResult> OutputAsync()
        {
            var exceptionHandler = await Task.FromResult(_httpContextAccessor.HttpContext.Features.Get<IExceptionHandlerPathFeature>());

            var responseDto = new ResponseBase<object>(
                code: exceptionHandler.Error.HResult,
                success: false,
                message: "Error",
                exception: exceptionHandler.Error.HResult < 0 ? ExceptionType.System : ExceptionType.Application,
                errors: new string[] { exceptionHandler.Error.Message },
                data: default
            );

            return new ObjectResult(responseDto)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
