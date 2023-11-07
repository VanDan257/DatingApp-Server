using System.ComponentModel.DataAnnotations;

namespace AppChat_Server.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        [MaxLength(16), MinLength(4)]
        public string Password { get; set; }
    }
}
