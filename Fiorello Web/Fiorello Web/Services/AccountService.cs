using Fiorello_Web.Helpers;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace Fiorello_Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginAsync(LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailOrUsername) ?? await _userManager.FindByEmailAsync(model.EmailOrUsername);
            if (user is null)
            {
                return SignInResult.Failed;
            }

            var result = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterVM model)
        {
            var user = new AppUser { FullName = model.FullName, Email = model.Email, UserName = model.Username};
            var result = await _userManager.CreateAsync(user, model.Password);
            var role = await _userManager.AddToRoleAsync(user, nameof(Role.Member));
            return result;
        }
    }
}
