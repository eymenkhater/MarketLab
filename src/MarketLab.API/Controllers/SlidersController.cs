using System.Threading.Tasks;
using MarketLab.API.Common.Controllers;
using MarketLab.Application.Sliders.Commands.CreateSlider;
using MarketLab.Application.Sliders.Commands.UpdateSlider;
using MarketLab.Application.Sliders.Queries.GeListSliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlidersController : MarketLabController
    {
        #region Fields
        private readonly ILogger<SlidersController> _logger;
        #endregion

        #region CTOR
        public SlidersController(
            ILogger<SlidersController> logger)
        {
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _mediator.Send(new GetListSliderQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSliderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSliderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(default));
        }
    }
}
