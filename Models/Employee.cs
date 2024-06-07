using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthDemo.Models
{
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("employee_number")]
        public string EmployeeNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(10)]
        [Column("gender")]
        public string Gender { get; set; }

        [MaxLength(15)]
        [Column("contact_number")]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Column("address_id")]
        public int? AddressId { get; set; }

        [Required]
        [Column("date_of_joining")]
        public DateTime DateOfJoining { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [Column("job_role_id")]
        public int? JobRoleId { get; set; }

        [MaxLength(255)]
        [Column("profile")]
        public string Profile { get; set; }

        [Column("supervisor_id")]
        public Guid? SupervisorId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = "Active";

        [MaxLength(20)]
        [Column("leave_status")]
        public string LeaveStatus { get; set; } = "None";
    }
}
