using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamDetailDTO
	{
        public int LessonName { get; set; }
        public int StudentName { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }
}
