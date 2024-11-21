using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
