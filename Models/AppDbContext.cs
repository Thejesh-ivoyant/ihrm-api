using AuthDemo.Models;
using IhrmApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace IhrmApi.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<LeaveRecord> LeaveRecords { get; set; }
        public DbSet<LeaveEncashment> LeaveEncashments { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<YearlyLeavePlan> YearlyLeavePlans { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<EmployeeTag> EmployeeTags { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Attendance> AttendanceRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<DocStorage> DocStorages { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Onboarding> Onboardings { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetServiceHistory> AssetServiceHistories { get; set; }
        public DbSet<Resignation> Resignations { get; set; }
        public DbSet<PerformanceAppraisal> PerformanceAppraisals { get; set; }

        // Ensure the DbContext is configured to use PostgreSQL
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use Npgsql if not configured externally
                optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=ihrm-db;Username=postgres;Password=thejesh");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply snake_case naming convention
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Configuration>().ToTable("configurations");
            modelBuilder.Entity<Project>().ToTable("projects");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Timesheet>().ToTable("timesheets");
            modelBuilder.Entity<LeaveRecord>().ToTable("leave_records");
            modelBuilder.Entity<LeaveEncashment>().ToTable("leave_encashment");
            modelBuilder.Entity<Reminder>().ToTable("reminders");
            modelBuilder.Entity<YearlyLeavePlan>().ToTable("yearly_leave_plan");
            modelBuilder.Entity<Department>().ToTable("departments");
            modelBuilder.Entity<EmployeeTag>().ToTable("employee_tags");
            modelBuilder.Entity<JobRole>().ToTable("job_roles");
            modelBuilder.Entity<Address>().ToTable("addresses");
            modelBuilder.Entity<ProjectAssignment>().ToTable("project_assignments");
            modelBuilder.Entity<LeaveType>().ToTable("leave_types");
            modelBuilder.Entity<Attendance>().ToTable("attendance");
            modelBuilder.Entity<Notification>().ToTable("notifications");
            modelBuilder.Entity<EmailTemplate>().ToTable("email_templates");
            modelBuilder.Entity<DocStorage>().ToTable("docstorage");
            modelBuilder.Entity<Certification>().ToTable("certifications");
            modelBuilder.Entity<Article>().ToTable("articles");
            modelBuilder.Entity<Learning>().ToTable("learning");
            modelBuilder.Entity<Onboarding>().ToTable("onboarding");
            modelBuilder.Entity<Vacancy>().ToTable("vacancies");
            modelBuilder.Entity<Asset>().ToTable("assets");
            modelBuilder.Entity<AssetServiceHistory>().ToTable("asset_service_history");
            modelBuilder.Entity<Resignation>().ToTable("resignations");
            modelBuilder.Entity<PerformanceAppraisal>().ToTable("performance_appraisals");
        }
    }
}