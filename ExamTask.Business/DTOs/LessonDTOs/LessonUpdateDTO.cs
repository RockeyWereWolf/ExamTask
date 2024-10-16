using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.LessonDTOs
{
    public class LessonUpdateDTO
    {
        public string LessonName { get; set; }
        public byte ClassNumber { get; set; }
        public int TeacherId { get; set; }

        public class LessonUpdateDTOValidator : AbstractValidator<LessonUpdateDTO>
        {
            public LessonUpdateDTOValidator()
            {
                RuleFor(l => l.LessonName)
                    .MaximumLength(30);
            }
        }
    }
}
