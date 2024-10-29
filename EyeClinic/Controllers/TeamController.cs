using Microsoft.AspNetCore.Mvc;

namespace EyeClinic.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
