using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class DocStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("storage_id")]
        public int StorageId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("document_name")]
        public string DocumentName { get; set; }

        [MaxLength(50)]
        [Column("document_type")]
        public string DocumentType { get; set; }

        [Column("upload_date")]
        public DateTime? UploadDate { get; set; }

        [MaxLength(255)]
        [Column("file_path")]
        public string FilePath { get; set; }
    }
}
