using mail;
using Microsoft.AspNetCore.Mvc;

namespace EyeClinic.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailsender;

        public ContactController(IEmailSender emailSender)
        {
            _emailsender = emailSender;
        }
      
        public async Task<IActionResult> Index()
        {
            var receiver = "shreya.prajapati@info.com.np";
            var subject = "test mail abcderf";
            var message = "hello shreya";
            await _emailsender.SendEmailAsync(receiver, subject, message);
            return View();
        }


    }
}
