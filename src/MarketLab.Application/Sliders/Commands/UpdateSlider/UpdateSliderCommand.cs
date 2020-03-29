using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Sliders.Commands.Base;

namespace MarketLab.Application.Sliders.Commands.UpdateSlider
{
    public class UpdateSliderCommand : SaveSliderCommand, ICommand<SliderDto>
    {
        public int Id { get; set; }
    }
}