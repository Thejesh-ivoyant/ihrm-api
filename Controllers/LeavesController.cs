using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IhrmApi.Models;
using AuthDemo.Models;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeavesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLeaves()
        {
            var leaves = _context.LeaveRecords.ToList();
            return Ok(leaves);
        }

        [HttpPost]
        public IActionResult CreateLeave([FromBody] LeaveRecord leave)
        {
            _context.LeaveRecords.Add(leave);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLeaves), new { id = leave.LeaveRecordId }, leave);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLeave(int id, [FromBody] LeaveRecord leave)
        {
            if (id != leave.LeaveRecordId)
            {
                return BadRequest();
            }

            _context.Entry(leave).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLeave(int id)
        {
            var leave = _context.LeaveRecords.Find(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.LeaveRecords.Remove(leave);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
