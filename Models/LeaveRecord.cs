using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class LeaveRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("leave_record_id")]
        public int LeaveRecordId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Required]
        [Column("total_leaves")]
        public int TotalLeaves { get; set; }

        [Required]
        [Column("remaining_leaves")]
        public int RemainingLeaves { get; set; }

        [Column("negative_leaves")]
        public int NegativeLeaves { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = "Pending";

        [Required]
        [Column("request_date")]
        public DateTime RequestDate { get; set; }

        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
