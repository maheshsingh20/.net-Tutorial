using Microsoft.AspNetCore.Mvc;
using Student.Models;
using System.Collections.Generic;
namespace Student.Controllers
{
  public class PupilController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Show(){
      List<Pupil> pupils = new List<Pupil>
      {
        new Pupil { Id = 1, Name = "Alice", Age = 14, Grade = "9th", City = "New York" },
        new Pupil { Id = 2, Name = "Bob", Age = 15, Grade = "10th", City = "Los Angeles" },
        new Pupil { Id = 3, Name = "Charlie", Age = 13, Grade = "8th", City = "Chicago" }
      };
      return View(pupils);
    }
  }
}