namespace BlazorApp.Data.Service;

public class EmailService: IEmailService
{
    private List<Email> _emails = new List<Email>();

    public EmailService()
    {
        _emails = new List<Email>();
        _emails.Add(new Email("Apurva","Apurveh","Test","Test",DateTime.Now));
        _emails.Add(new Email("Apurveh","Apurvuu","Test","Test",DateTime.Now));
        _emails.Add(new Email("Apurva","Apurvii","Test","Test",DateTime.Now));
        _emails.Add(new Email("Apurva","Apurvggg","Test","Test",DateTime.Now));
        _emails.Add(new Email("Apurva","Apurvooo","Test","Test",DateTime.Now));
    }
    public Task<Email> SendEmailAsync(Email email)
    {
        _emails.Add(email);
        return Task.FromResult(email);
    }

    public Task<Email[]> GetEmailsAsync()
    {
        Email[] emails = _emails.ToArray();
        return Task.FromResult(emails);
    }
}