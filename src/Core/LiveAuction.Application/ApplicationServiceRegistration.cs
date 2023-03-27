using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LiveAuction.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection
        services)
        => services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly()));
}