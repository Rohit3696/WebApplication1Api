using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1Api.Data;
using WebApplication1Api.Models;

namespace WebApplication1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountriesController(ApplicationDbContext context) 
        { 
            _context = context; 

        }
        [HttpGet]
        public IActionResult GetAllCountry()
        {
            return Ok(_context.Countries.ToList());
        }
        [HttpPost]
        public IActionResult AddCountry(Country Country)
        {
            _context.Countries.Add(Country);
            _context.SaveChanges();
            return Ok( " Country Added Successfully");
        }
        [HttpPut]
        public IActionResult UpdateCountry(Country Country)
        {
            _context.Countries.Update(Country);
            _context.SaveChanges();
            return Ok(" Country Updated Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteCountry(int id)
        {
            var Country = _context.Countries.Find(id);
            _context.Countries.Remove(Country);
            _context.SaveChanges();
            return Ok(" Country Deleted Successfully");
        }

    }
}
