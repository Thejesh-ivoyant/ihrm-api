using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class LeaveType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("leave_type_id")]
        public int LeaveTypeId { get; set; }

        [Required]
        [Column("leave_type_name")]
        public string LeaveTypeName { get; set; }
    }
}
