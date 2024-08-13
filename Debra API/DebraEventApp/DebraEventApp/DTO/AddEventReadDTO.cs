namespace DebraEventApp.DTO
{
    public class AddEventReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int PartnerId { get; set; }

    }
}
