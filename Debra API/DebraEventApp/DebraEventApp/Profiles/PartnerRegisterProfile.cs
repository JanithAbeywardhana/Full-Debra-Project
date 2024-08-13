using AutoMapper;
using DebraEventApp.DTO;
using DebraEventApp.Model;

namespace DebraEventApp.Profiles
{
    public class PartnerRegisterProfile : Profile
    {
        public PartnerRegisterProfile()
        {
            CreateMap<PartnerRegister, PartnerRegisterReadDTO>();
            CreateMap<PartnerRegisterCreateDTO, PartnerRegister>();
        }
    }
}