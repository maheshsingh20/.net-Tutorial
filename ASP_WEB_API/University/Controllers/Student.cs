using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
  [ApiController]
  [Route("api/[controller]/")]
  public class StudentController : ControllerBase
  {
    private List<Student> GetList()
    {
      return new List<Student>
            {
                new Student{Id=1,Name="Alice",Age=20},
                new Student{Id=2,Name="Bob",Age=22},
                new Student{Id=3,Name="Charlie",Age=21}
            };
    }
    [HttpGet]
    public IActionResult Get()
    {
      var students = GetList();
      if (students.Count == 0)
        return NoContent();
      return Ok(students);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var students = GetList();
      var student = students.FirstOrDefault(s => s.Id == id);
      if (student == null)
        return NotFound();
      return Ok(student);
    }
  }
}