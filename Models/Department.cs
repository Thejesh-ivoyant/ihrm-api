using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("department_name")]
        public string DepartmentName { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
