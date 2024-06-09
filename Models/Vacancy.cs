using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("vacancy_id")]
        public int VacancyId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("job_title")]
        public string JobTitle { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [Column("posted_date")]
        public DateTime? PostedDate { get; set; }

        [Column("closing_date")]
        public DateTime? ClosingDate { get; set; }

        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; }
    }
}
