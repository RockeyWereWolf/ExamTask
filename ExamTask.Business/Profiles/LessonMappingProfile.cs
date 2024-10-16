using AutoMapper;
using ExamTask.Business.DTOs.ExamDTOs;
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
            CreateMap<Lesson, LessonListDTO>();
            CreateMap<Lesson, LessonDetailDTO>();
        }
    }
}
