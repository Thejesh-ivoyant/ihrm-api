using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IhrmApi.Models
{
    
        public class Configuration
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ConfigId { get; set; }

            [Required]
            [MaxLength(100)]
            public string ConfigKey { get; set; }

            [Required]
            public string ConfigValue { get; set; }

            [Required]
            [MaxLength(50)]
            public string ConfigType { get; set; }

            public string Description { get; set; }
        }
   
}
