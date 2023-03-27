using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Models.Mail;
using LiveAuction.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveAuction.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this
        IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(
            "EmailSettings"));

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}