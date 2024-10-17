using ExamTask.Business.DTOs.UserDTOs;

namespace ExamTask.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(UserCreateDTO dto);
        public Task<IEnumerable<UserListDTO>> GetAllAsync();
        public Task<UserDetailDTO> GetByIdAsync(string id);
        public Task DeleteAsync(string id);
        public Task UpdateAsync(string id, UserUpdateDTO dto);
        public Task SoftDelete(string id);
        public Task ReverseSoftDelete(string id);
    }
}
