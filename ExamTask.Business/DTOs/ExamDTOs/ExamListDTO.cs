namespace ExamTask.Business.DTOs.ExamDTOs
{
	public class ExamListDTO
	{
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime ExamDate { get; set; }
        public byte Grade { get; set; }
    }
}

