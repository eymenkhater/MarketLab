using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Extensions;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Application.Products.Models.Responses;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;

namespace MarketLab.Application.Products.Queries.SearchProduct
{
    public class SearchProductQueryHandler : ResponseBaseHandler<SearchProductResponse>, IQueryHandler<SearchProductQuery, SearchProductResponse>
    {
        #region Feilds
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public SearchProductQueryHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<SearchProductResponse>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var products = (await _productRepository.ListAsync(request.Keyword)).ToDataQueryList(request);
            var productResponse = new SearchProductResponse
            (
                products: _mapper.Map<List<ProductDto>>(products)
            );

            return OK(productResponse);
        }
    }
}