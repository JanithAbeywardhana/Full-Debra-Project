using AutoMapper;
using DebraEventApp.DTO;
using DebraEventApp.Model;

namespace DebraEventApp.Profiles
{
    public class AddEventProfile : Profile
    {
        public AddEventProfile()
        {
            CreateMap<AddEvent, AddEventReadDTO>();
            CreateMap<AddEventCreateDTO, AddEvent>();
        }
    }
}