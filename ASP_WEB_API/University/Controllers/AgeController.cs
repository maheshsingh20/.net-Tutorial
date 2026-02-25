using Microsoft.AspNetCore.Mvc;
namespace University.Controllers{
  [ApiController]
  [Route("api/[controller]")]
  public class AgeController: ControllerBase{
    [HttpGet("{age}")]
    public IActionResult Get(int age){
      if(age<0){
        return BadRequest("Invalid Age");
      }
      return Ok($"Student age is {age}");
    }
  }
}