using AutoMapper;
using CourseManagementService.Models.Domains;
using CourseManagementService.Models.DTOs;
using CourseManagementService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IMapper mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            this.subjectRepository = subjectRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjectDomainModel = await subjectRepository.GetSubjectAsync();

            var subjectDTOModel = mapper.Map<List<SubjectDTO>>(subjectDomainModel);

            return Ok(subjectDTOModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] AddSubjectRequestDTO addSubjectRequestDTO)
        {
            var subjectDomainModel = mapper.Map<Subject>(addSubjectRequestDTO);
            subjectDomainModel = await subjectRepository.CreateSubjectAsync(subjectDomainModel);

            return Ok(mapper.Map<SubjectDTO>(subjectDomainModel));
        }

        [HttpDelete("{Code:guid}")]
        public async Task<IActionResult> DeleteSubject([FromRoute] Guid Code)
        {
            var subjectDomainModel = await subjectRepository.DeleteSubjectAsync(Code);

            if (subjectDomainModel is null)
                return NotFound();

            return Ok(mapper.Map<SubjectDTO>(subjectDomainModel));
        }

        [HttpPut("{Code:guid}")]
        public async Task<IActionResult> UpdateSubjectAsync([FromRoute] Guid Code, [FromBody] UpdateSubjectRequestDTO updateSubjectRequestDTO)
        {
            var subjectDomainModel = mapper.Map<Subject>(updateSubjectRequestDTO);

            subjectDomainModel = await subjectRepository.UpdateSubjectAsync(Code, subjectDomainModel);

            if (subjectDomainModel is null)
                return NotFound();

            return Ok(mapper.Map<SubjectDTO>(subjectDomainModel));
        }
    }
}
