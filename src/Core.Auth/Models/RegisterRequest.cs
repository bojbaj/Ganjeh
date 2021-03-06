using System.ComponentModel.DataAnnotations;

namespace Core.Auth.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        // [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Phone]
        // [Required(ErrorMessage = "Phone is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}