using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class YearlyLeavePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("plan_id")]
        public int PlanId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("plan_year")]
        public int Plan_Year { get; set; }

        [Required]
        [Column("leave_days")]
        public int LeaveDays { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
