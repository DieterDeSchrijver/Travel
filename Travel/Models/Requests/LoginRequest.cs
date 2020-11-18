
using System.ComponentModel.DataAnnotations;

namespace Travel.Domain.Models
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginRequest()
        {

        }
    }
}
