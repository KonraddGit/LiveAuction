using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LiveAuction.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<EmailService> _logger;

    public EmailService(
        IOptions<EmailSettings> mailSettings,
        ILogger<EmailService> logger)
    {
        _emailSettings = mailSettings.Value;
        _logger = logger;
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

        _logger.LogInformation("Email sent");

        if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
            response.StatusCode == System.Net.HttpStatusCode.OK)
            return true;

        _logger.LogError("Email sending failed");

        return false;
    }
}