using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LandingController : ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      Console.WriteLine("Welcome to the University API!");
      return "Welcome to the University API!";
    }
  }
}