using AutoMapper;
using StudentWebApi.Models.Domain;
using StudentWebApi.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentWebApi.Models.Domain;
using StudentWebApi.Models.DTO;

namespace StudentWebApi.Models.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DhrgStudentDetail, DhrgStudentDetailsDTO>().ReverseMap();
        }
    }
}
