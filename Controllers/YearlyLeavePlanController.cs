using Microsoft.AspNetCore.Mvc;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearlyLeavePlanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YearlyLeavePlanController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetYearlyLeavePlans()
        {
            var plans = _context.YearlyLeavePlans.ToList();
            return Ok(plans);
        }

        [HttpPost]
        public IActionResult CreateYearlyLeavePlan([FromBody] YearlyLeavePlan plan)
        {
            _context.YearlyLeavePlans.Add(plan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetYearlyLeavePlans), new { id = plan.PlanId }, plan);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateYearlyLeavePlan(int id, [FromBody] YearlyLeavePlan plan)
        {
            if (id != plan.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteYearlyLeavePlan(int id)
        {
            var plan = _context.YearlyLeavePlans.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.YearlyLeavePlans.Remove(plan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
