using Computers.Models;
using Microsoft.AspNetCore.Identity;

namespace Computers.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignupModel signupModel);
        Task<string> LoginAsync(SigninModel signinModel);
        Task<string> LogoutAsync();
    }
}
