using AutoMapper;
using DebraEventApp.DTO;
using DebraEventApp.Model;

namespace DebraEventApp.Profiles
{
    public class AddTicketProfile : Profile
    {
        public AddTicketProfile()
        {
            CreateMap<AddTicket, AddTicketReadDTO>();
            CreateMap<AddTicketCreateDTO, AddTicket>();
        }
    }
}