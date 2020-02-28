using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MarketLab.Application.Products.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ProductsController> _logger;
        #endregion

        #region CTOR
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region List Async
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return default;
        }
        #endregion

        #region Get Async
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromQuery, Required]int id)
        {
            return default;
        }
        #endregion

        #region Create Async
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
        {
            return default;
        }
        #endregion

        #region Update Async
        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductRequest request)
        {
            return default;
        }
        #endregion

        #region Delete Async
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            return default;
        }
        #endregion

    }
}
