using Microsoft.AspNetCore.Mvc;

namespace EyeClinic.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
