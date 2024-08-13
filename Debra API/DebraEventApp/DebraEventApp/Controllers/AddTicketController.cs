using Microsoft.AspNetCore.Mvc;
using DebraEventApp.Model;
using DebraEventApp.DTO;
using DebraEventApp.Data;
using AutoMapper;


namespace DebraEventApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAddTicketRepo _addTicketRepo;
        

        public AddTicketController( IAddTicketRepo AddTicketRepo, IMapper mapper)
        {
            _addTicketRepo = AddTicketRepo;
            _mapper = mapper;
           
        }

        [HttpPost]
        public ActionResult CreateAddTicket(AddTicketCreateDTO createDTO)
        {
            var model = _mapper.Map<AddTicket>(createDTO);
            model.Commission = model.Price * 0.10m; // I set the Calculate 10% commission for the each ticket.
            if (_addTicketRepo.CreateAddTicket(model))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("event/{eventId}")]
        public ActionResult<IEnumerable<AddTicketReadDTO>> GetTicketsByEventId(int eventId)
        {
            var addTicket = _addTicketRepo.GetTicketsByEventId(eventId);
            return Ok(_mapper.Map<IEnumerable<AddTicketReadDTO>>(addTicket));
        }

        [HttpPost("{id}")]
        public ActionResult SellTicket(int id)
        {
            var ticket = _addTicketRepo.GetAddTicket(id);
            if (ticket != null && !ticket.IsSold)
            {
                ticket.IsSold = true;
                ticket.SaleDate = DateTime.Now;
                if (_addTicketRepo.UpdateAddTicket(ticket))
                    return Ok("Ticket sold successfully.");
                else
                    return BadRequest("Error updating ticket status.");
            }
            else
            {
                return NotFound("Ticket not found or already sold.");
            }
        }











        [HttpGet]

        public ActionResult<IEnumerable<AddTicketCreateDTO>> GetAddTickets()
        {
            var addTicket = _addTicketRepo.GetAllAddTickets();
            return Ok(_mapper.Map<IEnumerable<AddTicketReadDTO>>(addTicket));
        }
        [HttpPut("{id}")]

        public ActionResult UpdateAddTicket(int id, AddTicketCreateDTO addTicketUpdate)
        {
            var addTicket = _mapper.Map<AddTicket>(addTicketUpdate);
            addTicket.Id = id;
            if (_addTicketRepo.UpdateAddTicket(addTicket))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteAddTicket(int id)
        {
            var addTicket = _addTicketRepo.GetAddTicket(id);
            if (_addTicketRepo.DeleteAddTicket(addTicket))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet("{id}", Name = "GetsByID1")]

        public ActionResult<AddTicketReadDTO> GetAddTicket(int id)
        {
            var addTicket = _addTicketRepo.GetAddTicket(id);
            if (addTicket != null)
                return Ok(_mapper.Map<AddTicketReadDTO>(addTicket));
            else
                return NotFound();
        }

        

        
    }
}
