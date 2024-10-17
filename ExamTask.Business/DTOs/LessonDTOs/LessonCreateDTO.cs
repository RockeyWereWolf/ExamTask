using FluentValidation;

namespace ExamTask.Business.DTOs.LessonDTOs
{
    public class LessonCreateDTO
    {
        public string LessonName { get; set; }
        public byte ClassNumber { get; set; }
        public string TeacherId { get; set; }

        public class LessonCreateDTOValidator : AbstractValidator<LessonCreateDTO>
        {
            public LessonCreateDTOValidator()
            {
                RuleFor(l => l.LessonName)
                    .MaximumLength(30);
                RuleFor(l => l.TeacherId)
                    .NotEmpty();
                RuleFor(x => x.ClassNumber)
                    .InclusiveBetween((byte)1, (byte)11);
            }
        }
    }
}
