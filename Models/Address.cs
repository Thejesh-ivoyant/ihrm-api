using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("address_id")]
        public int AddressId { get; set; }

        [MaxLength(255)]
        [Column("address_line")]
        public string AddressLine { get; set; }

        [MaxLength(50)]
        [Column("city")]
        public string City { get; set; }

        [MaxLength(50)]
        [Column("state")]
        public string State { get; set; }

        [MaxLength(10)]
        [Column("postal_code")]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        [Column("country")]
        public string Country { get; set; }
    }
}
