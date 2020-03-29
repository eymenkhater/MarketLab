using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;

namespace MarketLab.Application.Sliders.Queries.GeListSliders
{
    public class GetListSliderQueryHandler : ResponseBaseHandler<List<SliderDto>>, IQueryHandler<GetListSliderQuery, List<SliderDto>>
    {
        #region Fields
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public GetListSliderQueryHandler(
            ISliderRepository sliderRepository,
            IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<List<SliderDto>>> Handle(GetListSliderQuery request, CancellationToken cancellationToken)
        {
            var slidersDto = _mapper.Map<List<SliderDto>>(await _sliderRepository.ListAsync());

            return OK(slidersDto);
        }
    }
}