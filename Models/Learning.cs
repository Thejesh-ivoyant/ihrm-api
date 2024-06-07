using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Learning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("learning_id")]
        public int LearningId { get; set; }

        [Column("author_id")]
        public Guid? AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("course_name")]
        public string CourseName { get; set; }

        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; }

        [MaxLength(100)]
        [Column("file")]
        public string File { get; set; }
    }
}
