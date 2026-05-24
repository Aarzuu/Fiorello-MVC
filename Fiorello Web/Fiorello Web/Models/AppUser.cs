using Microsoft.AspNetCore.Identity;

namespace Fiorello_Web.Models
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
