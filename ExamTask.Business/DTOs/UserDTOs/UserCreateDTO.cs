using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte? ClassNumber { get; set; }
        public string? Role { get; set; }

        public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
        {
            public UserCreateDTOValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(64);
                RuleFor(x => x.Surname)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(64);
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(16);
                RuleFor(x => x.ClassNumber)
                    .InclusiveBetween((byte)1, (byte)11)
                    .When(x => x.ClassNumber.HasValue);

            }
        }
    }
}
