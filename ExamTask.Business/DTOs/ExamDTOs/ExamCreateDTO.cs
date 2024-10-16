using FluentValidation;

namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamCreateDTO
	{
		public int LessonId { get; set; }
		public int StudentId { get; set; }
		public DateTime ExamDate { get; set; }
		public byte Grade { get; set; }
	}

	public class ExamCreateDTOValidator : AbstractValidator<ExamCreateDTO>
	{
		public ExamCreateDTOValidator()
		{

        }
	}
}
