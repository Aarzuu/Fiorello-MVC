using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAdminAsync();
            return View(sliders);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _sliderService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var slider = await _sliderService.GetByIDAsync((int)id);

            if (slider is null)
            {
                return NotFound();
            }

            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var slider = await _sliderService.GetByIDAsync((int)id);

            if (slider is null)
            {
                return NotFound();
            }

            await _sliderService.DeleteAsync((int)id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var slider = await _sliderService.GetByIDAsync((int)id);

            if (slider is null)
            {
                return NotFound();
            }

            return View(new SliderUpdateVM { Image = slider.Image });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM? model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (id is null)
            {
                return BadRequest();
            }
            var slider = await _sliderService.GetByIDAsync((int)id);

            await _sliderService.UpdateAsync((int)id, model);
            return RedirectToAction("Index");
        }
    }
}