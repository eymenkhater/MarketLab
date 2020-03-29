using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Extensions;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Application.Sliders.Commands.Base;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.Sliders.Entities;

namespace MarketLab.Application.Sliders.Commands.UpdateSlider
{
    public class UpdateSliderCommandHandler : ResponseBaseHandler<SliderDto>, ICommandHandler<UpdateSliderCommand, SliderDto>
    {
        #region Fields
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public UpdateSliderCommandHandler(
            ISliderRepository sliderRepository,
            IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<SliderDto>> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _sliderRepository.GetAsync(request.Id);
            slider = _mapper.Map(request, slider);

            (await _sliderRepository.UpdateAsync(slider)).ThrowIfRejected();

            var slidersDto = _mapper.Map<SliderDto>(slider);

            return OK(slidersDto);
        }
    }
}