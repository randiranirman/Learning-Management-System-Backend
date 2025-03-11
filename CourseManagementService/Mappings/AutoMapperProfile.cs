using AutoMapper;
using CourseManagementService.Models.Domains;
using CourseManagementService.Models.DTOs;

namespace CourseManagementService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }
    }
}
