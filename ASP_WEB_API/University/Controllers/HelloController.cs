using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        [HttpGet("{name}")]
        public string Get(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
