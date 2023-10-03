using System.ComponentModel.DataAnnotations;

namespace DatingApp_Server.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        [MaxLength(8), MinLength(4)]
        public string password { get; set; }
    }
}
