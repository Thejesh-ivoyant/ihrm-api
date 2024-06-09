using Microsoft.AspNetCore.Mvc;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveEncashmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveEncashmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CalculateLeaveEncashment([FromBody] LeaveEncashment request)
        {
            var employee = _context.Employees.Find(request.EmployeeId);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var leaveEncashment = new LeaveEncashment
            {
                EmployeeId = request.EmployeeId,
                EncashmentDate = DateTime.UtcNow,
                LeaveDays = request.LeaveDays,
                EncashmentAmount = request.LeaveDays * 10 // salary need to be added
            };

            _context.LeaveEncashments.Add(leaveEncashment);
            _context.SaveChanges();

            return Ok(leaveEncashment);
        }
    }
}
