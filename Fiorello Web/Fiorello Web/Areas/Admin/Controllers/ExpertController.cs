using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Expert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExpertController : Controller
    {
        private readonly IExpertService _expertService;
        public ExpertController(IExpertService expertService)
        {
            _expertService = expertService;
        }

        public async Task<IActionResult> Index()
        {
            var experts = await _expertService.GetAllAdminAsync();
            return View(experts);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpertCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _expertService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            await _expertService.DeleteAsync((int) id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();   
            }
            var expert = await _expertService.GetByIDAsync((int) id);
            if (expert is null)
            {
                return NotFound();
            }
            return View(expert);
        }

        [HttpGet]
        public async Task<IActionResult> Update (int? id)
        {
            if (id is null )
            {
                return BadRequest();
            }
            var expert = await _expertService.GetByIDAsync((int)id);
            if (expert is null)
            {
                return NotFound();
            }
            return View(new ExpertUpdateVM { Image = expert.Image, Name = expert.Name, Profession = expert.Profession });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ExpertUpdateVM model)
        {
            
            if (id is null)
            {
                return BadRequest();
            }
            var expert = await _expertService.GetByIDAsync((int)id);
            if (expert is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) 
            {
                expert.Image = model.Image;
                return View(model);
            }

            await _expertService.UpdateAsync((int)id, model);
            return RedirectToAction("Index");
        }
    }
}
