using DebraEventApp.Model;

namespace DebraEventApp.Data
{
    public interface IAddTicketRepo
    {
        bool Save();
        AddTicket GetAddTicket(int Id);
        bool CreateAddTicket(AddTicket addTicket);
        bool UpdateAddTicket(AddTicket addTicket);
        bool DeleteAddTicket(AddTicket addTicket);
        IEnumerable<AddTicket> GetAllAddTickets();
        IEnumerable<AddTicket> GetTicketsByEventId(int eventId); // New method
    }
}