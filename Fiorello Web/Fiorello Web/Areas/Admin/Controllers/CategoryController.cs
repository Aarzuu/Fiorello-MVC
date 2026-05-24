using Fiorello_Web.Models;
using Fiorello_Web.Services;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
         _categoryService = categoryService;
                
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAdminAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id) 
        {
            if (id is null)
            {
                return BadRequest();
            }

            var category = await _categoryService.GetByIDAsync(id.Value);

            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var category = await _categoryService.GetByIDAsync(id.Value);

            if (category is null)
            {
                return NotFound();
            }

            return View(new CategoryUpdateVM { Name = category.Name });

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int? id, CategoryUpdateVM category) 
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (id is null)
            {
                return BadRequest();
            }

            var data = await _categoryService.GetByIDAsync(id.Value);

            if (data is null)
            {
                return NotFound();
            }

            await _categoryService.UpdateAsync(id.Value, category);
            return RedirectToAction(nameof(Index));

        }

    }
}
