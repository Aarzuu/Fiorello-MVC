using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogservice;

        public BlogController(IBlogService blogService)
        {
            _blogservice = blogService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id) 
        { 
            var blog = await _blogservice.GetByIDAsync(id);
            return View(blog);
        }
    }
}
