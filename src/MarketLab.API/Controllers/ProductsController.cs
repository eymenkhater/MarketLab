using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MarketLab.API.Common.Controllers;
using MarketLab.Application.Core.Queries.Primitives;
using MarketLab.Application.Listings.Queries.GetFeaturedListings;
using MarketLab.Application.Listings.Queries.GetSelectedProductListings;
using MarketLab.Application.Products.Commands.ImportProducts;
using MarketLab.Application.Products.Models.Requests;
using MarketLab.Application.Products.Queries.SearchProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : MarketLabController
    {
        #region Fields
        private readonly ILogger<ProductsController> _logger;
        #endregion

        #region CTOR
        public ProductsController(
            ILogger<ProductsController> logger
            )
        {
            _logger = logger;
        }
        #endregion

        #region Search Async
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> SearchAsync(string keyword)
        {
            var query = new SearchProductQuery()
            {
                Searching = new List<SearchingQuery> { new SearchingQuery() { Field = "name", Keyword = keyword } },
                Paging = new PagingQuery() { Page = 1, ItemsPerPage = 1000 }
            };
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region Import Async
        [HttpPost("import/{resourceId}")]
        public async Task<IActionResult> ImportAsync(int resourceId, [FromBody] List<ImportProductRequest> products)
        {
            return Ok(await _mediator.Send(new ImportProductsCommand(resourceId, products)));
        }
        #endregion


        #region Search Async
        [HttpGet("listings/{productId}")]
        public async Task<IActionResult> SelectedListingsAsync(int productId)
        {
            return Ok(await _mediator.Send(new GetSelectedProductListingsQuery(productId)));
        }
        #endregion

        #region Search Async
        [HttpGet("listings/featured")]
        public async Task<IActionResult> FeaturedListingsAsync()
        {
            return Ok(await _mediator.Send(new GetFeaturedListingsQuery()));
        }
        #endregion

    }
}
