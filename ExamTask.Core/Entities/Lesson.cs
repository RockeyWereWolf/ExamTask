namespace ExamTask.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public string LessonName { get; set; }
        public byte ClassNumber { get; set; }
        public string TeacherId { get; set; }
        public AppUser Teacher { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}
