using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Application.Listings.Models.Responses;
using MarketLab.Application.Listings.Queries.GetFeaturedListings;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;

namespace MarketLab.Application.Listings.Queries.GetFeaturedListing
{
    public class GetFeaturedListingsQueryHandler : ResponseBaseHandler<List<FeaturedListingsResponse>>, IQueryHandler<GetFeaturedListingsQuery, List<FeaturedListingsResponse>>
    {
        #region Feilds
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public GetFeaturedListingsQueryHandler(
            IListingRepository listingRepository,
            IMapper mapper)
        {
            _listingRepository = listingRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<List<FeaturedListingsResponse>>> Handle(GetFeaturedListingsQuery request, CancellationToken cancellationToken)
        {
            var listings = await _listingRepository.ListFeaturedAsync();
            var featuredListingsResponse = new List<FeaturedListingsResponse>();

            foreach (var item in listings)
            {
                var productDto = _mapper.Map<FeaturedListingsResponse>(item.Product);
                productDto.Listing = _mapper.Map<ListingDto>(item);
                productDto.Resource = _mapper.Map<ResourceDto>(item.Resource);
                productDto.ProductImage = _mapper.Map<ProductImageDto>(item.Product.ProductImages.FirstOrDefault(q => !q.IsDeleted));
                featuredListingsResponse.Add(productDto);
            }

            return OK(featuredListingsResponse);
        }
    }
}