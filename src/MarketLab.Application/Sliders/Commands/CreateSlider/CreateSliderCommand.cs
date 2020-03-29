using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Sliders.Commands.Base;

namespace MarketLab.Application.Sliders.Commands.CreateSlider
{
    public class CreateSliderCommand : SaveSliderCommand, ICommand<SliderDto>
    {

    }
}