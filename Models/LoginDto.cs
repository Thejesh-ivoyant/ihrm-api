using System.ComponentModel.DataAnnotations;

namespace IhrmApi.Models
{
    public class LoginDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
