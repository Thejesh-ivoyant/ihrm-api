using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class PerformanceAppraisal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("appraisal_id")]
        public int AppraisalId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("appraisal_date")]
        public DateTime AppraisalDate { get; set; }

        [Required]
        [Column("performance_score")]
        public int PerformanceScore { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [Required]
        [Column("reviewer_id")]
        public Guid ReviewerId { get; set; }
    }
}
