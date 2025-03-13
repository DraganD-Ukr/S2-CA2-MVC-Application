using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace S2_CA2_MVC_MovieApp.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        _logger.LogInformation($"Email sent to: {email}\nSubject: {subject}\nMessage: {htmlMessage}");
        return Task.CompletedTask;
    }
}