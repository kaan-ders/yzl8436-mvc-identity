using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class RegisterModel
    {
        [Required]
        public string AdiSoyadi { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }
    }
}