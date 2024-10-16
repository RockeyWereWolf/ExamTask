using AutoMapper;
using ExamTask.Business.DTOs.LessonDTOs;
using ExamTask.Business.Exceptions.Common;
using ExamTask.Business.Repositories.Interfaces;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Core.Entities;

namespace ExamTask.Business.Services.Implements
{
    public class LessonService : ILessonService
    {
        readonly ILessonRepository _repo;
        readonly IMapper _mapper;

        public LessonService(ILessonRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(LessonCreateDTO lesson)
        {
            var data = _mapper.Map<Lesson>(lesson);
            await _repo.CreateAsync(data);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Delete(data);
            await _repo.SaveAsync();
        }

        public IEnumerable<LessonListDTO> GetAll()
            => _mapper.Map<IEnumerable<LessonListDTO>>(_repo.GetAll(includes: "AppUser")); //.Include(x=> x.AppUser)
        public async Task<LessonDetailDTO> GetByIdAsync(int id)
        {
            var data = await _checkId(id, true);
            return _mapper.Map<LessonDetailDTO>(data);
        }

        public async Task UpdateAsync(int id, LessonUpdateDTO dto)
        {
            var data = await _checkId(id);
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _checkId(id);
            data.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _checkId(id);
            data.IsDeleted = false;
            await _repo.SaveAsync();
        }

        async Task<Lesson> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack, "AppUser");
            if (data == null) throw new NotFoundException<Lesson>();
            return data;
        }
    }
}
