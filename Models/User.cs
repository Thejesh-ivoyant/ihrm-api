using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IhrmApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; }

        [Column("failed_login_attempts")]
        public int? FailedLoginAttempts { get; set; }

        [Column("lockout_end")]
        public DateTime? LockoutEnd { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
