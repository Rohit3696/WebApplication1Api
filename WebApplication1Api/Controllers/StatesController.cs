using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1Api.Data;
using WebApplication1Api.Models;

namespace WebApplication1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public StatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStates()
        {
            var state = _context.States.ToList();
            return Ok(state);
        }

        [HttpPost]
        public IActionResult AddState(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return Ok(" State Added Successfully");
        }
        [HttpPut]
        public IActionResult UpdateState(State State)
        {
            _context.States.Update(State);
            _context.SaveChanges();
            return Ok(" State Updated Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteState(int id)
        {
            var State = _context.States.Find(id);
            _context.States.Remove(State);
            _context.SaveChanges();
            return Ok(" State Deleted Successfully");
        }

    }
}
