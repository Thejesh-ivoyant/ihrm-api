using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimesheetsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTimesheets()
        {
            var timesheets = _context.Timesheets.ToList();
            return Ok(timesheets);
        }

        [HttpPost]
        public IActionResult CreateTimesheet([FromBody] Timesheet timesheet)
        {
            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTimesheets), new { id = timesheet.TimesheetId }, timesheet);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTimesheet(int id, [FromBody] Timesheet timesheet)
        {
            if (id != timesheet.TimesheetId)
            {
                return BadRequest();
            }

            _context.Entry(timesheet).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimesheet(int id)
        {
            var timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.Timesheets.Remove(timesheet);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
