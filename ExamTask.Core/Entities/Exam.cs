using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Core.Entities
{
    public class Exam : BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string StudentId { get; set; }
        public AppUser Student { get; set; }
        public DateTime ExamDate {  get; set; }
        public byte Grade { get; set; }
    }
}
