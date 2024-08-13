using System.Linq;
using DebraEventApp.Model;

namespace DebraEventApp.Data
{
    public class PartnerRegisterRepo : IPartnerRegisterRepo
    {
        private AppDBContext _dbContext;

        public PartnerRegisterRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PartnerRegister Login(string email, string password)
        {
            return _dbContext.PartnerRegisters.FirstOrDefault(p => p.Email == email && p.Password == password);
        }

        public bool CreatePartnerRegister(PartnerRegister partnerRegister)
        {
            if (partnerRegister != null)
            {
                _dbContext.PartnerRegisters.Add(partnerRegister);
                return Save();
            }
            else
                return false;
        }

        public bool DeletePartnerRegister(PartnerRegister partnerRegister)
        {
            if (partnerRegister != null)
            {
                _dbContext.PartnerRegisters.Remove(partnerRegister);
                return Save();
            }
            else
                return false;
        }

        public IEnumerable<PartnerRegister> GetAllPartnerRegisters()
        {
            return _dbContext.PartnerRegisters.ToList();
        }

        public PartnerRegister GetPartnerRegister(int id)
        {
            return _dbContext.PartnerRegisters.FirstOrDefault(PartnerRegister => PartnerRegister.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdatePartnerRegister(PartnerRegister partnerRegister)
        {
            _dbContext.PartnerRegisters.Update(partnerRegister);
            return Save();
        }
    }
}