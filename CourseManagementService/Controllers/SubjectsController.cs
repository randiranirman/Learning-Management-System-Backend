using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjectsDomainModel = new
            {
                Id = 1,
                Name = "subject 1",
                AssignDate = new DateOnly()
            };

            return Ok(subjectsDomainModel);
        }
    }
}
