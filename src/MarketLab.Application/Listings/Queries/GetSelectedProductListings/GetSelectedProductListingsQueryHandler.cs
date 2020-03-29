using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Application.Listings.Models.Responses;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;

namespace MarketLab.Application.Listings.Queries.GetSelectedProductListings
{
    public class GetSelectedProductListingsQueryHandler : ResponseBaseHandler<List<SelectedProductListingsResponse>>, IQueryHandler<GetSelectedProductListingsQuery, List<SelectedProductListingsResponse>>
    {
        #region Feilds
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public GetSelectedProductListingsQueryHandler(
            IListingRepository listingRepository,
            IMapper mapper)
        {
            _listingRepository = listingRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<List<SelectedProductListingsResponse>>> Handle(GetSelectedProductListingsQuery request, CancellationToken cancellationToken)
        {
            var listings = await _listingRepository.ListAsync(request.ProductId);

            var selectedProductListingsResponse = _mapper.Map<List<SelectedProductListingsResponse>>(listings);

            return OK(selectedProductListingsResponse);
        }
    }
}