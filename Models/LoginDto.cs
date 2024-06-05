using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
