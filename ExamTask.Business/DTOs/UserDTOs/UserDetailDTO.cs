using ExamTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.UserDTOs
{
    public class UserDetailDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte? ClassNumber { get; set; }
        public IEnumerable<Lesson>? Lessons { get; set; }
        public string Role { get; set; }
    }
}
