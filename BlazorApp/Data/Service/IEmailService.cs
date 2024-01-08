namespace BlazorApp.Data.Service;

public interface IEmailService
{
    Task<Email> SendEmailAsync(Email email);
    Task<Email[]> GetEmailsAsync();
}