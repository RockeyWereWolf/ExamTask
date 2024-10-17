using AutoMapper;
using ExamTask.Business.DTOs.LessonDTOs;
using ExamTask.Core.Entities;

namespace ExamTask.Business.Profiles
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<LessonCreateDTO, Lesson>();
            CreateMap<LessonUpdateDTO, Lesson>();
            CreateMap<Lesson, LessonListDTO>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name))
                .ForMember(dest => dest.TeacherSurname, opt => opt.MapFrom(src => src.Teacher.Surname));
            CreateMap<Lesson, LessonDetailDTO>();
            CreateMap<LessonDetailDTO, LessonUpdateDTO>();
        }
    }
}
