using System.ComponentModel.DataAnnotations;

namespace DebraEventApp.DTO
{
    public class PartnerLoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
