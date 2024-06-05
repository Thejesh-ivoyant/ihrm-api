

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Users Table
namespace AuthDemo.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public int? EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }
        public int? FailedLoginAttempts { get; set; }
        public DateTime? LockoutEnd { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }
    }

    // OAuthClients Table
    public class OAuthClient
    {
        [Key]
        [MaxLength(100)]
        public string ClientID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientSecret { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string RedirectUris { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string GrantTypes { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Scope { get; set; }

        [MaxLength(100)]
        public string ClientName { get; set; }
    }

    // OAuthTokens Table
    public class OAuthToken
    {
        [Key]
        public int TokenID { get; set; }

        [Required]
        [MaxLength(255)]
        public string AccessToken { get; set; }

        [MaxLength(255)]
        public string RefreshToken { get; set; }

        public DateTime? ExpiresAt { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Scope { get; set; }

        [MaxLength(100)]
        public string ClientID { get; set; }

        public int? UserID { get; set; }

        [ForeignKey("ClientID")]
        public OAuthClient Client { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }

    // Departments Table
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
    }

    // JobRoles Table
    public class JobRole
    {
        [Key]
        public int JobRoleID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
    }

    // Employees Table
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(20)]
        public string EmployeeNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(15)]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        public int? DepartmentID { get; set; }

        public int? JobRoleID { get; set; }

        public int? SupervisorID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [MaxLength(20)]
        public string LeaveStatus { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        [ForeignKey("JobRoleID")]
        public JobRole JobRole { get; set; }

        [ForeignKey("SupervisorID")]
        public Employee Supervisor { get; set; }
    }

    // Projects Table
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }

    // ProjectAssignments Table
    public class ProjectAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public int? EmployeeID { get; set; }

        public int? ProjectID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }

    // Timesheets Table
    public class Timesheet
    {
        [Key]
        public int TimesheetID { get; set; }

        public int? EmployeeID { get; set; }

        public int? ProjectID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }

    // LeaveRecords Table
    public class LeaveRecord
    {
        [Key]
        public int LeaveRecordID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }

        [Required]
        public int TotalLeaves { get; set; }

        [Required]
        public int RemainingLeaves { get; set; }

        public int NegativeLeaves { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("LeaveTypeID")]
        public LeaveType LeaveType { get; set; }
    }

    // LeaveTypes Table
    public class LeaveType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveTypeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string LeaveTypeName { get; set; }
    }

    // LeaveEncashment Table
    public class LeaveEncashment
    {
        [Key]
        public int EncashmentID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime EncashmentDate { get; set; }

        [Required]
        public int LeaveDays { get; set; }

        [Required]
        public decimal EncashmentAmount { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // Attendance Table
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public TimeSpan? CheckInTime { get; set; }

        public TimeSpan? CheckOutTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // YearlyLeavePlan Table
    public class YearlyLeavePlan
    {
        [Key]
        public int PlanID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int LeaveDays { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }
    // Notifications Table
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // EmailTemplates Table
    public class EmailTemplate
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TemplateName { get; set; }

        [MaxLength(255)]
        public string Subject { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Body { get; set; }
    }

    // Reminders Table
    public class Reminder
    {
        [Key]
        public int ReminderID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }

        [Required]
        public DateTime ReminderDate { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // Storage Table
    public class StorageItem
    {
        [Key]
        public int StorageID { get; set; }

        [Required]
        [MaxLength(255)]
        public string DocumentName { get; set; }

        [MaxLength(50)]
        public string DocumentType { get; set; }

        public DateTime? UploadDate { get; set; }

        [MaxLength(255)]
        public string FilePath { get; set; }
    }

    // Certifications Table
    public class Certification
    {
        [Key]
        public int CertificationID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CertificationName { get; set; }

        [MaxLength(100)]
        public string IssuingOrganization { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // Articles Table
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        public int? AuthorID { get; set; }

        public DateTime? PublishDate { get; set; }

        [ForeignKey("AuthorID")]
        public Employee Author { get; set; }
    }

    // Learning Table
    public class Learning
    {
        [Key]
        public int LearningID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [MaxLength(100)]
        public string Provider { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // OnBoarding Table
    public class OnBoarding
    {
        [Key]
        public int OnBoardingID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime OnBoardingDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Remarks { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // Vacancies Table
    public class Vacancy
    {
        [Key]
        public int VacancyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        public int? DepartmentID { get; set; }

        public DateTime? PostedDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }

    // Assets Table
    public class Asset
    {
        [Key]
        public int AssetID { get; set; }

        [Required]
        [MaxLength(100)]
        public string AssetName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        public int? AssignedTo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Condition { get; set; }

        [ForeignKey("AssignedTo")]
        public Employee AssignedEmployee { get; set; }
    }


    // AssetServiceHistory Table
    public class AssetServiceHistory
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        public int AssetID { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ServiceReason { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ServiceDetails { get; set; }

        [ForeignKey("AssetID")]
        public Asset Asset { get; set; }
    }

    // Resignations Table
    public class Resignation
    {
        [Key]
        public int ResignationID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime ResignationDate { get; set; }

        [Required]
        public DateTime LastWorkingDate { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }

    // Performance Appraisals Table
    public class PerformanceAppraisal
    {
        [Key]
        public int AppraisalID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime AppraisalDate { get; set; }

        [Required]
        public int PerformanceScore { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Comments { get; set; }

        public int? ReviewerID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("ReviewerID")]
        public Employee Reviewer { get; set; }
    }

   
    




}


