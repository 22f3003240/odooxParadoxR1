using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CP.Main.Services;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using CP.Main.ViewModel;

public class HomeController : Controller
{
    private readonly MongoDbService _mongoDbService;

    public HomeController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Find user by username
        var users = await _mongoDbService.GetUsersAsync();
        var user = users.FirstOrDefault(u => u.UserName == model.Username);

        if (user != null && user.Password == model.Password)
        {
            // Set session or authentication cookie
            HttpContext.Session.SetString("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

            // Redirect to a protected page or dashboard
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View(model);
        }
    }

    public IActionResult Dashboard()
    {
        // Example protected page
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Login()
    {
        return RedirectToAction("Index", "UserDashboard");
    }
}
