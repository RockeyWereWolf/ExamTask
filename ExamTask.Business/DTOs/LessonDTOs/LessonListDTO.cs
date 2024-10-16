using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.LessonDTOs
{
    public class LessonListDTO
    {
        public string LessonName { get; set; }
        public byte ClassNumber { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}
