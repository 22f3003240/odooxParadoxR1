using Microsoft.AspNetCore.Mvc;

namespace CP.Main.Controllers
{
    public class UserDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
