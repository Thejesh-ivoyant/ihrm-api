using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class LeaveEncashment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("encashment_id")]
        public int EncashmentId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("encashment_date")]
        public DateTime EncashmentDate { get; set; }

        [Required]
        [Column("leave_days")]
        public int LeaveDays { get; set; }

        [Required]
        [Column("encashment_amount")]
        public decimal EncashmentAmount { get; set; }
    }
}
