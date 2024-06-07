using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("certification_id")]
        public int CertificationId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("certification_name")]
        public string CertificationName { get; set; }

        [MaxLength(100)]
        [Column("issuing_organization")]
        public string IssuingOrganization { get; set; }

        [Column("issue_date")]
        public DateTime? IssueDate { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Status { get; set; }

        [MaxLength(15)]
        [Column("completion_status")]
        public string CompletionStatus { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [MaxLength(255)]
        [Column("certificate_file")]
        public string CertificateFile { get; set; }
    }
}
