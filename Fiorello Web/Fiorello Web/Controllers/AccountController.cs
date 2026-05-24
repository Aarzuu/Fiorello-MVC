using Fiorello_Web.Helpers;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IAccountService accountService, RoleManager<IdentityRole> roleManager)
        {
            _accountService = accountService;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _accountService.RegisterAsync(model);
            if (!result.Succeeded)
            {
                foreach (var i in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, i.Description);

                }
                return View(model);
            }
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _accountService.LoginAsync(model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "User and password do not match.");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index","Home");
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    foreach (var r in Enum.GetValues(typeof(Role)))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = r.ToString() });
        //    }
        //    return Ok();
        //}


        // admin email:  arzu@gmail.com 
        // admin password: Password.00 
    }
}
