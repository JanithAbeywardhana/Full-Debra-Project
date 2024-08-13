namespace DebraEventApp.DTO
{
    public class PartnerRegisterReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;

    }
}
