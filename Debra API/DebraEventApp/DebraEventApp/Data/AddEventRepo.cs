using DebraEventApp.Model;

namespace DebraEventApp.Data
{
    public class AddEventRepo : IAddEventRepo
    {
        private AppDBContext _dbContext;

        public AddEventRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAddEvent(AddEvent addEvent)
        {
            if (addEvent != null)
            {
                _dbContext.AddEvents.Add(addEvent);
                return Save();
            }
            else
                return false;
        }

        public bool DeleteAddEvent(AddEvent addEvent)
        {
            if (addEvent != null)
            {
                _dbContext.AddEvents.Remove(addEvent);
                return Save();
            }
            else
                return false;
        }

        public IEnumerable<AddEvent> GetAllAddEvents()
        {
            return _dbContext.AddEvents.ToList();
        }

        public AddEvent GetAddEvent(int id)
        {
            return _dbContext.AddEvents.FirstOrDefault(AddEvent => AddEvent.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateAddEvent(AddEvent addEvent)
        {
            if (!_dbContext.PartnerRegisters.Any(p => p.Id != addEvent.PartnerId))
            {
                throw new InvalidOperationException("Invalid PartnerId");
            }


            _dbContext.AddEvents.Update(addEvent);
            return Save();
        }

        public IEnumerable<AddEvent> GetEventsByPartnerId(int partnerId)
        {
            return _dbContext.AddEvents.Where(e => e.PartnerId == partnerId).ToList();
        }
    }
}