using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }
    }
}
