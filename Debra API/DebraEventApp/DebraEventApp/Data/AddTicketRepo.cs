using DebraEventApp.Model;

namespace DebraEventApp.Data
{
    public class AddTicketRepo : IAddTicketRepo
    {
        private readonly AppDBContext _dbContext;

        public AddTicketRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAddTicket(AddTicket addTicket)
        {
            if (addTicket != null)
            {
                _dbContext.AddTickets.Add(addTicket);
                return Save();
            }
            else
                return false;
        }

        public bool DeleteAddTicket(AddTicket addTicket)
        {
            if (addTicket != null)
            {
                _dbContext.AddTickets.Remove(addTicket);
                return Save();
            }
            else
                return false;
        }

        public IEnumerable<AddTicket> GetAllAddTickets()
        {
            return _dbContext.AddTickets.ToList();
        }

        public AddTicket GetAddTicket(int id)
        {
            return _dbContext.AddTickets.FirstOrDefault(AddTicket => AddTicket.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateAddTicket(AddTicket addTicket)
        {
            _dbContext.AddTickets.Update(addTicket);
            return Save();
        }

        public IEnumerable<AddTicket> GetTicketsByEventId(int eventId)
        {
            return _dbContext.AddTickets.Where(t => t.EventId == eventId).ToList();
        }
    }
}