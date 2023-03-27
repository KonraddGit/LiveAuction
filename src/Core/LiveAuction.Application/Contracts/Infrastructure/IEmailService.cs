using LiveAuction.Application.Models.Mail;

namespace LiveAuction.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}