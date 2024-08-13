using DebraEventApp.Model;
namespace DebraEventApp.Data
{
    public interface IPartnerRegisterRepo
    {
        bool Save();
        PartnerRegister GetPartnerRegister(int id);
        bool CreatePartnerRegister(PartnerRegister partnerRegister);
        bool UpdatePartnerRegister(PartnerRegister partnerRegister);
        bool DeletePartnerRegister(PartnerRegister partnerRegister);
        PartnerRegister Login(string email, string password);
        IEnumerable<PartnerRegister> GetAllPartnerRegisters();

    }
}
