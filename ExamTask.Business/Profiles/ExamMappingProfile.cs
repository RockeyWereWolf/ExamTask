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
			CreateMap<Exam, ExamListDTO>();
			CreateMap<Exam, ExamDetailDTO>();
		}
	}
}
