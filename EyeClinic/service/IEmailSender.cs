namespace mail
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string name, string senderemail, string phone, string subject, string message);
    }
}
