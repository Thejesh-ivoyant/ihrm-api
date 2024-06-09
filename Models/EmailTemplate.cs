using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class EmailTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("template_id")]
        public int TemplateId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("template_name")]
        public string TemplateName { get; set; }

        [MaxLength(255)]
        [Column("subject")]
        public string Subject { get; set; }

        [Column("body")]
        public string Body { get; set; }
    }
}
