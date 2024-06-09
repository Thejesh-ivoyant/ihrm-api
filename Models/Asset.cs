using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("asset_id")]
        public int AssetId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("asset_name")]
        public string AssetName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("purchase_date")]
        public DateTime? PurchaseDate { get; set; }

        [Column("warranty_expiry_date")]
        public DateTime? WarrantyExpiryDate { get; set; }

        [Column("assigned_to")]
        public Guid? AssignedTo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("asset_status")]
        public string AssetStatus { get; set; }
    }
}
