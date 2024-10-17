using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte? ClassNumber { get; set; }
        public IEnumerable<Lesson>? Lessons { get; set; }
        public IEnumerable<Exam>? Exams { get; set; }
        public bool IsDeleted { get; set; }
    }
}
