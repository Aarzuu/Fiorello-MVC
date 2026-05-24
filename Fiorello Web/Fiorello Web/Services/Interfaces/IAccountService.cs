using Fiorello_Web.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace Fiorello_Web.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterVM model);
        Task<SignInResult> LoginAsync(LoginVM model);
        Task LogoutAsync();
    }
}
