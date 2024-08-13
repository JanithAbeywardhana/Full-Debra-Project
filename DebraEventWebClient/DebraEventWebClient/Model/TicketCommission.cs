namespace DebraEventWebClient.Model
{
    public class TicketCommission
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsSold { get; set; }

        public decimal Price { get; set; }

        public decimal Commission { get; set; }
    }
}
