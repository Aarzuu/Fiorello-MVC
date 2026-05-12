
using Fiorello_Web.Data;
using Fiorello_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fiorello_Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

    }
}
