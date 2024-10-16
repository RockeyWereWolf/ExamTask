using ExamTask.Business.DTOs.ExamDTOs;

namespace ExamTask.Business.Services.Interfaces
{
	public interface IExamService
	{
		public IEnumerable<ExamListDTO> GetAll();
		public Task<ExamDetailDTO> GetByIdAsync(int id);
		public Task CreateAsync(ExamCreateDTO exam);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, ExamUpdateDTO exam);
		public Task SoftDelete(int id);
        public Task ReverseSoftDelete(int id);
    }
}
