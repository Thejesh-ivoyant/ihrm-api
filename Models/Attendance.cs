using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("attendance_id")]
        public int AttendanceId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("check_in_time")]
        public TimeSpan? CheckInTime { get; set; }

        [Column("check_out_time")]
        public TimeSpan? CheckOutTime { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; }
    }
}
