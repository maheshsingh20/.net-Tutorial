using Microsoft.AspNetCore.Mvc;
namespace Student.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
