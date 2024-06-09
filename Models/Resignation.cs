using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Resignation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("resignation_id")]
        public int ResignationId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("resignation_date")]
        public DateTime ResignationDate { get; set; }

        [Required]
        [Column("last_working_date")]
        public DateTime LastWorkingDate { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = "Pending";
    }
}
