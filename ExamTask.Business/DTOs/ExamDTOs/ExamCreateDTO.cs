using FluentValidation;

namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamCreateDTO
	{
		public int LessonId { get; set; }
		public string StudentId { get; set; }
		public DateTime ExamDate { get; set; }
		public byte Grade { get; set; }
	}

	public class ExamCreateDTOValidator : AbstractValidator<ExamCreateDTO>
	{
		public ExamCreateDTOValidator()
		{
			RuleFor(x => x.LessonId)
				.NotEmpty();
			RuleFor(x => x.StudentId)
				.NotEmpty();
			RuleFor(x => x.ExamDate)
				.NotEmpty();
			RuleFor(x => x.Grade)
				.NotEmpty()
				.InclusiveBetween((byte)1, (byte)5);
        }
	}
}
