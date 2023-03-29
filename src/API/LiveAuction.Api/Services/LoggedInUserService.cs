using LiveAuction.Application.Contracts;
using System.Security.Claims;

namespace LiveAuction.Api.Services;

public class LoggedInUserService : ILoggedInUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId
    {
        get => _httpContextAccessor
            .HttpContext?
            .User?
            .FindFirstValue(ClaimTypes.NameIdentifier);
    }
}