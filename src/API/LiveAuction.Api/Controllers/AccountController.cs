using LiveAuction.Application.Contracts.Identity;
using LiveAuction.Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(
            AuthenticationRequest request)
            => Ok(await _authenticationService.AuthenticateAsync(request));

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(
            RegistrationRequest request)
            => Ok(await _authenticationService.RegisterAsync(request));
    }
}
