using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LiveAuction.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _emailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmailAsync(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;

        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject,
            emailBody, emailBody);

        var response = await client.SendEmailAsync(sendGridMessage);

        if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
            response.StatusCode == System.Net.HttpStatusCode.OK)
            return true;

        return false;
    }
}