
using IhrmApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Authorization;
using IhrmApi.Repository;

namespace IhrmApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { message = "This is a protected endpoint." });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.users.SingleOrDefault(u => u.UserId == loginDto.UserId);
           
            if (user == null)
            {
                return Unauthorized();
            }

            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.UtcNow)
            {
                return Forbid("Account is locked. Try again later.");
            }

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                if (user.FailedLoginAttempts == null)
                {
                    user.FailedLoginAttempts = 1;
                }
                else
                {
                    user.FailedLoginAttempts++;
                }

                if (user.FailedLoginAttempts >= 3) 
                {
                    user.LockoutEnd = DateTime.UtcNow.AddMinutes(15); // Lock for 15 minutes
                    Console.WriteLine($"User {user.UserId} is locked out due to too many failed login attempts.");
                }
                _context.SaveChanges();
                return Unauthorized();
            }

            user.FailedLoginAttempts = null;
            user.LockoutEnd = null;
            _context.SaveChanges();

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
      
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[1]);

            using (var argon2 = new Konscious.Security.Cryptography.Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 8; 
                argon2.MemorySize = 1024 * 1024; 
                argon2.Iterations = 4;

                var computedHash = argon2.GetBytes(16);
                Console.WriteLine($"Stored hash: {Convert.ToBase64String(hash)}");
                Console.WriteLine($"Computed hash: {Convert.ToBase64String(computedHash)}");

                var result = computedHash.SequenceEqual(hash);
                return result;
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] signUpDto signupDto)
        {
           
            if (_context.users.Any(u => u.UserId == signupDto.UserId))
            {
                return Conflict("Username already exists.");
            }
           
            var (salt, hash) = HashPassword(signupDto.Password);
   
            var newUser = new User
            {
                UserId = signupDto.UserId,
                PasswordHash = $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}",
                Email = "Vishruthaa@ivoyant.com"
                
      
            };

            _context.users.Add(newUser);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }

        private (byte[] salt, byte[] hash) HashPassword(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] hash;

            using (var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {

                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 8;
                argon2.MemorySize = 1024 * 1024; 
                argon2.Iterations = 4;

              
                hash = argon2.GetBytes(16);
            }

            return (salt, hash);
        }
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

    }


}