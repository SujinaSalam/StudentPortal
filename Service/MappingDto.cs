using AutoMapper;
using StudentPortal.Models;
using StudentPortal.Models.DTO;

namespace StudentPortal.Service
{
    public class MappingDto : Profile
    {
        public MappingDto()
        {
            CreateMap<StudentDto, Student>().ReverseMap();        
        }
    }
}
