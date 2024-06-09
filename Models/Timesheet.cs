using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Timesheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("timesheet_id")]
        public int TimesheetId { get; set; }

        [Required]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Column("timesheet_date")]
        public DateTime TimesheetDate { get; set; }

        [MaxLength(10)]
        [Column("weeks")]
        public string Weeks { get; set; }

        [Column("period_from")]
        public DateTime PeriodFrom { get; set; }

        [Column("period_to")]
        public DateTime PeriodTo { get; set; }

        [Column("office_holidays")]
        public int OfficeHolidays { get; set; }

        [Column("pto_leave")]
        public int PtoLeave { get; set; }

        [Column("days_worked")]
        public int DaysWorked { get; set; }

        [Column("total_hours_worked")]
        public int TotalHoursWorked { get; set; }

        [Column("timesheets_attached")]
        public bool TimesheetsAttached { get; set; }

        [MaxLength(50)]
        [Column("purchase_order")]
        public string PurchaseOrder { get; set; }

        [MaxLength(255)]
        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("submitted_date")]
        public DateTime? SubmittedDate { get; set; }

        [Required]
        [Column("hours_worked")]
        public decimal HoursWorked { get; set; }
    }
}
