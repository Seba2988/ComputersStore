using Computers.Models;
using Computers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Computers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel signupModel)
        {
            var result = await _accountRepository.SignUpAsync(signupModel);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SigninModel signinModel)
        {
            var result = await _accountRepository.LoginAsync(signinModel);
            if (string.IsNullOrEmpty(result)) return Unauthorized();
            return Ok(result);
        }
    }
}
