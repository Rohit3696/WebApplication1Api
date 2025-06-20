using Microsoft.AspNetCore.Mvc;
using WebApplication1Api.Data;
using WebApplication1Api.Models;

namespace WebApplication1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDistricts()
        {
            var districts = _context.Districts.ToList();
            return Ok(districts);
        }

        [HttpPost]
        public IActionResult AddDistrict([FromBody] District district)
        {
            if (district == null)
            {
                return BadRequest("Invalid district data.");
            }

            _context.Districts.Add(district);
            _context.SaveChanges();
            return Ok("District added successfully.");
        }

        [HttpPut]
        public IActionResult UpdateDistrict([FromBody] District district)
        {
            if (district == null || district.Id == 0)
            {
                return BadRequest("Invalid district data.");
            }

            var existingDistrict = _context.Districts.Find(district.Id);
            if (existingDistrict == null)
            {
                return NotFound($"District with ID {district.Id} not found.");
            }

            _context.Entry(existingDistrict).CurrentValues.SetValues(district);
            _context.SaveChanges();
            return Ok("District updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var district = _context.Districts.Find(id);
            if (district == null)
            {
                return NotFound($"District with ID {id} not found.");
            }

            _context.Districts.Remove(district);
            _context.SaveChanges();
            return Ok("District deleted successfully.");
        }
    }
}
