using FluentValidation;

namespace ExamTask.Business.DTOs.ExamDTOs
{
    public class ExamUpdateDTO
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }

    public class ExamUpdateDTOValidator : AbstractValidator<ExamUpdateDTO>
    {
        public ExamUpdateDTOValidator()
        {

        }
    }
}