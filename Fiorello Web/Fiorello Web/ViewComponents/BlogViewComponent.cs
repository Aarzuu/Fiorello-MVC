using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var blogs = await _blogService.GetAllAsync();

            if (count.HasValue)
            {
                blogs = blogs.Take(count.Value).ToList();
            }

            return View(blogs);
        }
    }
}
