using LiveAuction.Application.Models.Authentication;

namespace LiveAuction.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
}