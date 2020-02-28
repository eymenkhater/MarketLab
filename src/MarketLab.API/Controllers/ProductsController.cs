using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Application.Products.Services;
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
        private readonly IProductService _productService;
        #endregion

        #region CTOR
        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
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
        [HttpPut]
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

        #region Import Async
        [HttpPost("import")]
        public async Task<IActionResult> ImportAsync([FromBody] ImportProductsRequest request)
        {
            await _productService.ImportAsync(request);
            return Ok();
        }
        #endregion

    }
}
