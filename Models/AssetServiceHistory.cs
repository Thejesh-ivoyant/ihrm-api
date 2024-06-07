using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class AssetServiceHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("service_id")]
        public int ServiceId { get; set; }

        [Required]
        [Column("asset_id")]
        public int AssetId { get; set; }

        [Required]
        [Column("service_date")]
        public DateTime ServiceDate { get; set; }

        [Column("service_reason")]
        public string ServiceReason { get; set; }

        [Column("service_details")]
        public string ServiceDetails { get; set; }
    }
