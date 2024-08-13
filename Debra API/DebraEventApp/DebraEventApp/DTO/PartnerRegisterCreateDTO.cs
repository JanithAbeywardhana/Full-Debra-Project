using System.ComponentModel.DataAnnotations;
namespace DebraEventApp.DTO
{
    public class PartnerRegisterCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;


    }
}
