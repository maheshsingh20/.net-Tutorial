using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GreetingController : ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      Console.WriteLine("Hello from the GreetingController!");
      return "Greetings!";
    }
    [HttpGet("{name}/{message}")]
    public string Get(string name, string message)
    {
      Console.WriteLine($"Hello {name}, {message} from the GreetingController!");
      return $"{name}, Greetings , {message}!";
    }
  }
}