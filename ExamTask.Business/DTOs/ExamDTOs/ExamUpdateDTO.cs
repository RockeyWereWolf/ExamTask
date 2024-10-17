using FluentValidation;

namespace ExamTask.Business.DTOs.ExamDTOs
{
    public class ExamUpdateDTO
    {
        public int LessonId { get; set; }
        public string StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }

    public class ExamUpdateDTOValidator : AbstractValidator<ExamUpdateDTO>
    {
        public ExamUpdateDTOValidator()
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