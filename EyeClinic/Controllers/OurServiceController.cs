using Microsoft.AspNetCore.Mvc;

namespace EyeClinic.Controllers
{
    public class OurServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
