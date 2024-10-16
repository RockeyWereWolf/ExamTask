using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Core.Entities;

namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamListDTO
	{
        public int LessonName { get; set; }
        public int StudentName { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }
}

