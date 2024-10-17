using AutoMapper;
using ExamTask.Business.DTOs.ExamDTOs;
using ExamTask.Core.Entities;

namespace ExamTask.Business.Profiles
{
	public class ExamMappingProfile : Profile
	{
		public ExamMappingProfile()
		{
			CreateMap<ExamCreateDTO, Exam>();
			CreateMap<ExamUpdateDTO, Exam>();
			CreateMap<Exam, ExamListDTO>()
				.ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
				.ForMember(dest => dest.StudentSurname, opt => opt.MapFrom(src => src.Student.Surname))
				.ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.LessonName));
            CreateMap<Exam, ExamDetailDTO>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
                .ForMember(dest => dest.StudentSurname, opt => opt.MapFrom(src => src.Student.Surname));
            CreateMap<ExamDetailDTO, ExamUpdateDTO>();
        }
	}
}
