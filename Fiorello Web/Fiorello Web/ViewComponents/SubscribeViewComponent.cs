using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class SubscribeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
