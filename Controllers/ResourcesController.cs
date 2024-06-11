using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResourcesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetResources()
        {
            var resources = _context.Employees.ToList();
            return Ok(resources);
        }

        [HttpPost]
        public IActionResult CreateResource([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetResources), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResource(Guid id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResource(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
