using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class ExpertViewComponent :ViewComponent
    {
        private readonly IExpertService _expertService;
        public ExpertViewComponent(IExpertService expertService)
        {
            _expertService = expertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experts = await _expertService.GetAllAsync();
            return View(experts);
        }
    }
}
