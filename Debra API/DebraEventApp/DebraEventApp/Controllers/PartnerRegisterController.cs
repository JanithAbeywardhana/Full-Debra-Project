using Microsoft.AspNetCore.Mvc;
using DebraEventApp.Model;
using DebraEventApp.DTO;
using DebraEventApp.Data;
using AutoMapper;

namespace DebraEventApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerRegisterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRegisterRepo _partnerRegisterRepo;

        public PartnerRegisterController(IPartnerRegisterRepo PartnerRegisterRepo, IMapper mapper)
        {
            _partnerRegisterRepo = PartnerRegisterRepo;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult<PartnerRegisterReadDTO> Login(PartnerLoginDTO loginDTO)
        {
            var partner = _partnerRegisterRepo.Login(loginDTO.Email, loginDTO.Password);
            if (partner == null)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<PartnerRegisterReadDTO>(partner));
        }

        [HttpPost]
        public ActionResult CreatePartnerRegister(PartnerRegisterCreateDTO createDTO)
        {
            var model = _mapper.Map<PartnerRegister>(createDTO);
            if (_partnerRegisterRepo.CreatePartnerRegister(model))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<PartnerRegisterReadDTO>> GetPartnerRegisters()
        {
            var partnerRegister = _partnerRegisterRepo.GetAllPartnerRegisters();
            return Ok(_mapper.Map<IEnumerable<PartnerRegisterReadDTO>>(partnerRegister));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePartnerRegister(int id, PartnerRegisterCreateDTO partnerRegisterUpdate)
        {
            var partnerRegister = _mapper.Map<PartnerRegister>(partnerRegisterUpdate);
            partnerRegister.Id = id;
            if (_partnerRegisterRepo.UpdatePartnerRegister(partnerRegister))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePartnerRegister(int id)
        {
            var partnerRegister = _partnerRegisterRepo.GetPartnerRegister(id);
            if (_partnerRegisterRepo.DeletePartnerRegister(partnerRegister))
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("{id}", Name = "GetByID2")]
        public ActionResult<PartnerRegisterReadDTO> GetPartnerRegister(int id)
        {
            var partnerRegister = _partnerRegisterRepo.GetPartnerRegister(id);
            if (partnerRegister != null)
                return Ok(_mapper.Map<PartnerRegisterReadDTO>(partnerRegister));
            else
                return NotFound();
        }
    }
}