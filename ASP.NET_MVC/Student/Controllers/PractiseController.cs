using Microsoft.AspNetCore.Mvc;

namespace Student.Controllers
{
    public class PractiseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
