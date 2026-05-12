using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderContextService _sliderContextService;
        private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderContextService sliderContextService, ISliderService sliderService)
        {
            _sliderContextService = sliderContextService;
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderContext = await _sliderContextService.GetContextAsync();
            var sliders = await _sliderService.GetAllAsync();

            SliderVMVC model = new() { SliderContext = sliderContext, Sliders = sliders };
            return View(model);
        }
    }

    public class SliderVMVC
    {
        public SliderContext SliderContext { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
    
}
