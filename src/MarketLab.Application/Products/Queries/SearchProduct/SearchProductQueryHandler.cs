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
using MarketLab.Application.Products.Dtos;
using MarketLab.Application.Products.Models.Responses;
using MarketLab.Application.SearchLogs.Commands.CreateSearcLog;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Listings.Entities;
using MediatR;

namespace MarketLab.Application.Products.Queries.SearchProduct
{
    public class SearchProductQueryHandler : ResponseBaseHandler<SearchProductResponse>, IQueryHandler<SearchProductQuery, SearchProductResponse>
    {
        #region Feilds
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        #endregion

        #region CTOR
        public SearchProductQueryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion
        public async Task<ResponseBase<SearchProductResponse>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListSearchAsync(request.Searching[0].Keyword);
            products = products.ToDataQueryList(request);

            if (request.Searching.Any())
                await _mediator.Send(new CreateSearchLogCommand(request.Searching[0].Keyword, products.Count));

            var productsDto = new List<ProductSearchDto>();
            foreach (var item in products)
            {
                var productDto = _mapper.Map<ProductSearchDto>(item);
                productDto.MinPrice = item.Listings.Min(q => q.Price);
                productDto.ProductImages = _mapper.Map<List<ProductImageDto>>(item.ProductImages);
                productDto.Resources = _mapper.Map<List<ResourceDto>>(item.Listings.Select(q => q.Resource));

                productsDto.Add(productDto);
            }

            var productResponse = new SearchProductResponse(productsDto);

            return OK(productResponse);
        }
    }
}