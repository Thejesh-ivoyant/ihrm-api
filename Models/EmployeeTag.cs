using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class EmployeeTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tag_id")]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("tag_name")]
        public string TagName { get; set; }

    }
}
