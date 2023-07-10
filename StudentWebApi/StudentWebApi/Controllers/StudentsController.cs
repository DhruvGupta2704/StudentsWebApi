using AutoMapper;
using Azure;
using KafkaPractice.Models;
using KafkaPractice.Models.Domain;
using KafkaPractice.Models.DTO;
using KafkaPractice.Models.RepositoryPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KafkaPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly SaxotempdbContext _context;
        private readonly IDhrgStudentDetailRepository studentDetailRepository;
        private readonly IMapper mapper;

        public StudentsController(IDhrgStudentDetailRepository studentDetailRepository, IMapper mapper)
        {
            //_context = context;
            this.studentDetailRepository = studentDetailRepository;
            this.mapper = mapper;
        }
        //[HttpGet]
        /*public async Task<IActionResult> GetAll()
        {
            var dhrgStudentDomain = await studentDetailRepository.GetAllAsync();
            var studentDetailDto = mapper.Map<List<DhrgStudentDetailsDTO>>(dhrgStudentDomain);

            return Ok(studentDetailDto);



        }*/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dhrgStudentDomain = studentDetailRepository.GetAllAysnc();
            //var studentDetailDto = mapper.Map<List<DhrgStudentDetailsDTO>>(dhrgStudentDomain);
            return StatusCode(200, dhrgStudentDomain);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentDetailByIdDomain = await studentDetailRepository.GetByIdAsync(id);
            return Ok(mapper.Map<DhrgStudentDetailsDTO>(studentDetailByIdDomain));
            //return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {

            var deleteStudentDetailModel = await studentDetailRepository.DeleteAsync(id);
            if (deleteStudentDetailModel == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<DhrgStudentDetailsDTO>(deleteStudentDetailModel));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateById(int id, DhrgStudentDetail detail)
        {
            var existingStudentDomain = await studentDetailRepository.UpdateAsync(id, detail);
            if (existingStudentDomain == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<DhrgStudentDetailsDTO>(existingStudentDomain));

        }
        [HttpPost]
        public async Task<IActionResult> Create(DhrgStudentDetail detail)
        {

            var createStudentModel = await studentDetailRepository.CreateAsync(detail);
            var studentDto = mapper.Map<DhrgStudentDetailsDTO>(detail);
            return Ok(studentDto);

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<DhrgStudentDetail> detail)
        {

            var existingStudentDomain = await studentDetailRepository.PartialUpdateAsync(id, detail);
            if (existingStudentDomain == null)
            {
                return BadRequest(nameof(existingStudentDomain));
            }

            return Ok(existingStudentDomain);

        }

    }

}