using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}