using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Dtos;
using StudentsApi.Interfaces;
using StudentsApi.Models;

namespace StudentsApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentsRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await _studentsRepository.GetAll();
            var studentDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await _studentsRepository.GetByIdAsync(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            if (student == null) return NotFound("Student Not Found");

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var studentPosted = await _studentsRepository.CreateStudent(student);
            var studentDb = _mapper.Map<StudentDto>(studentPosted);
            return CreatedAtAction("GetAll", new { student.Id }, studentDto);
        }


    }
}