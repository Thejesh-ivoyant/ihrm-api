using Microsoft.AspNetCore.Mvc;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceReminderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttendanceReminderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendAttendanceReminder([FromBody] Reminder request)
        {
            var employee = _context.Employees.Find(request.EmployeeId);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var reminder = new Reminder
            {
                EmployeeId = request.EmployeeId,
                Message = request.Message,
                ReminderDateTime = DateTime.UtcNow
            };

            _context.Reminders.Add(reminder);
            _context.SaveChanges();

            // Logic to send the reminder (e.g., via email or notification)
            // ...

            return Ok();
        }
    }
}
