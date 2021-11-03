using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class User
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(50)]
        public string Password { get; set; }
    }
}