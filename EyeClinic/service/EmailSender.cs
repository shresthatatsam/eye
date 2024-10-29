using System.Net;
using System.Net.Mail;

namespace mail
{

public class EmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        public EmailSender(IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration");
            _fromEmail = emailConfig["From"];
            _smtpServer = emailConfig["SmtpServer"];
            _port = int.Parse(emailConfig["Port"]);
            _username = emailConfig["Username"];
            _password = emailConfig["Password"];
        }

        public async Task SendEmailAsync(string email,string name , string senderemail, string phone, string subject, string message)
        {
            using (var client = new SmtpClient(_smtpServer, _port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_username, _password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderemail),
                    Subject = subject,
                    Body = $@"
                <table style='border-collapse: collapse; width: 100%;'>
                    <tr>
                        <th style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>Name</th>
                        <th style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>Message</th>
                        <th style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>Phone</th>
                        <th style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>Sender Email</th>
                    </tr>
                    <tr>
                        <td style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>{name}</td>
                        <td style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>{message}</td>
                        <td style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>{phone}</td>
                        <td style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>{senderemail}</td>
                    </tr>
                </table>",
                    IsBodyHtml = true 
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
