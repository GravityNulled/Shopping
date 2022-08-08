using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Dtos;
using StudentsApi.Interfaces;
using StudentsApi.Models;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationsController : ControllerBase
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly IMapper _mapper;
        public IdentificationsController(IIdentificationRepository identificationRepository, IMapper mapper)
        {
            _identificationRepository = identificationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationDto>>> GetAll()
        {
            var ids = await _identificationRepository.GetAll();
            var mappedId = _mapper.Map<IEnumerable<IdentificationDto>>(ids);
            return Ok(mappedId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IdentificationDto>> GetByIdAsync(int id)
        {
            var identification = await _identificationRepository.GetByIdAsync(id);
            if (identification == null) return NotFound();
            var mappedId = _mapper.Map<IdentificationDto>(identification);
            return Ok(mappedId);
        }

        [HttpPost]
        public async Task<ActionResult<IdentificationDto>> Post([FromBody] IdentificationDto identificationDto)
        {
            var id = _mapper.Map<Identification>(identificationDto);
            await _identificationRepository.CreateAsync(id);
            var mappedId = _mapper.Map<IdentificationDto>(id);
            return CreatedAtAction("GetAll", new { id = mappedId.Id }, mappedId);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<IdentificationDto>> Delete(int id)
        {
            var idToDelete = await _identificationRepository.Delete(id);
            var mappedId = _mapper.Map<IdentificationDto>(idToDelete);
            return Ok(mappedId);
        }
    }
}