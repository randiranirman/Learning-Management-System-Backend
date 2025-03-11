using AutoMapper;
using CourseManagementService.Models.DTOs;
using CourseManagementService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IMapper mapper;

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teacherDomainModel = await teacherRepository.GetAllAsync();

            return Ok(mapper.Map<List<TeacherDTO>>(teacherDomainModel));
        }
    }
}
