using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamDetailDTO
	{
        public string LessonName { get; set; }
        public int LessonId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }
}
