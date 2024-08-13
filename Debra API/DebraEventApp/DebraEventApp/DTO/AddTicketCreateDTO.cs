using System.ComponentModel.DataAnnotations;

namespace DebraEventApp.DTO
{
    public class AddTicketCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter value bigger than {1}")]
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public decimal Commission { get; set; }
        public DateTime? SaleDate { get; set; }
        public int EventId { get; set; }


    }
}
