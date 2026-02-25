using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      List<Student> students = new List<Student>
      {
        new Student{Id=1,Name="Alice",Age=20},
        new Student{Id=2,Name="Bob",Age=22},
        new Student{Id=3,Name="Charlie",Age=21}
      };
      return Ok(students);
    }
  }
}