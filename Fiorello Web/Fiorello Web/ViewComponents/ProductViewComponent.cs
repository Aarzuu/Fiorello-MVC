using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class ProductViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public ProductViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
