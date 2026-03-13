using Microsoft.AspNetCore.Mvc;

namespace Level2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private static List<string> cities = new List<string>
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Phoenix"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= cities.Count)
            {
                return NotFound("City not found");
            }
            return Ok(cities[id]);
        }

        [HttpPost]
        public IActionResult Create([FromBody] string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return BadRequest("City name cannot be empty");
            }
            cities.Add(cityName);
            return CreatedAtAction(nameof(GetById), new { id = cities.Count - 1 }, cityName);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string cityName)
        {
            if (id < 0 || id >= cities.Count)
            {
                return NotFound("City not found");
            }
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return BadRequest("City name cannot be empty");
            }
            cities[id] = cityName;
            return Ok(cities[id]);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= cities.Count)
            {
                return NotFound("City not found");
            }
            cities.RemoveAt(id);
            return NoContent();
        }
    }
}
