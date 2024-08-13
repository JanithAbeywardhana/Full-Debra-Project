using AutoMapper;
using DebraEventApp.Data;
using DebraEventApp.DTO;
using DebraEventApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DebraEventApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAddEventRepo _addEventRepo;

        public AddEventController(IAddEventRepo AddEventRepo, IMapper mapper)
        {
            _addEventRepo = AddEventRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAddEvent(AddEventCreateDTO createDTO, int partnerId)
        {
            var model = _mapper.Map<AddEvent>(createDTO);
            model.PartnerId = partnerId; // Set the partner ID
            if (_addEventRepo.CreateAddEvent(model))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("partner/{partnerId}")]
        public ActionResult<IEnumerable<AddEventReadDTO>> GetEventsByPartnerId(int partnerId)
        {
            var addEvents = _addEventRepo.GetEventsByPartnerId(partnerId);
            return Ok(_mapper.Map<IEnumerable<AddEventReadDTO>>(addEvents));
        }














        [HttpGet]

        public ActionResult<IEnumerable<AddEventCreateDTO>> GetAddEvents()
        {
            var addEvents = _addEventRepo.GetAllAddEvents();
            return Ok(_mapper.Map<IEnumerable<AddEventReadDTO>>(addEvents));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateAddEvent(int id, AddEventCreateDTO addEventUpdate)
        {
            var addEvent = _mapper.Map<AddEvent>(addEventUpdate);
            addEvent.Id = id;

            try
            {
                if (_addEventRepo.UpdateAddEvent(addEvent))
                    return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the event.");
            }

            return NotFound();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteAddEvent(int id)
        {
            var addEvents = _addEventRepo.GetAddEvent(id);
            if (_addEventRepo.DeleteAddEvent(addEvents))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet("{id}", Name = "GetsByID")]

        public ActionResult<AddEventReadDTO> GetAddEvent(int id)
        {
            var addEvents = _addEventRepo.GetAddEvent(id);
            if (addEvents != null)
                return Ok(_mapper.Map<AddEventReadDTO>(addEvents));
            else
                return NotFound();
        }
    }
}
