using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1Api.Data;

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
    }
}
