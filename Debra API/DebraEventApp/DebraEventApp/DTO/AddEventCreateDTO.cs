using System.ComponentModel.DataAnnotations;
namespace DebraEventApp.DTO
{
    public class AddEventCreateDTO
    {
        [Required]

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }
    }
}
