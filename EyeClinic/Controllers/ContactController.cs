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

        public IActionResult Index()
        {
            return View();

        }

            public async Task<IActionResult> createEmail(string name , string email ,string phone, string subject, string message)
        {
            try
            {
                var receiver = "meetadityaprasad@gmail.com";
                
                await _emailsender.SendEmailAsync(receiver,name , email,phone , subject, message);
                return View("Index");
            }
            catch (Exception ex) 
            {
                throw ex;
            }
         
        }


    }
}
