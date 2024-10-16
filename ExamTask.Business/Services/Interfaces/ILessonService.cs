using ExamTask.Business.DTOs.LessonDTOs;

namespace ExamTask.Business.Services.Interfaces
{
    public interface ILessonService
    {
        public IEnumerable<LessonListDTO> GetAll();
        public Task<LessonDetailDTO> GetByIdAsync(int id);
        public Task CreateAsync(LessonCreateDTO lesson);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, LessonUpdateDTO lesson);
        public Task SoftDelete(int id);
        public Task ReverseSoftDelete(int id);
    }
}
