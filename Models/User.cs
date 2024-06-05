using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public int? FailedLoginAttempts { get; set; } 
        public DateTime? LockoutEnd { get; set; }
    }

    public class Asset
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

    }

}
