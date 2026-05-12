using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class ExpertViewComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
