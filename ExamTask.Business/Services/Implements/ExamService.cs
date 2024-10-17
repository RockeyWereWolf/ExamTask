using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ExamTask.Business.DTOs.ExamDTOs;
using ExamTask.Business.Exceptions.Common;
using ExamTask.Business.Repositories.Interfaces;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Core.Entities;

namespace ExamTask.Business.Services.Implements
{
	public class ExamService : IExamService
	{
		readonly IExamRepository _repo;
		readonly IMapper _mapper;
		readonly IHttpContextAccessor _contextAccessor;
		readonly UserManager<AppUser> _userManager;
		readonly string _userId;

		public ExamService(IExamRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
        }

		public async Task CreateAsync(ExamCreateDTO exam)
		{
			var data = _mapper.Map<Exam>(exam);
            await _repo.CreateAsync(data);
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _checkId(id);
			_repo.Delete(data);
			await _repo.SaveAsync();
		}

		public IEnumerable<ExamListDTO> GetAll()
			=> _mapper.Map<IEnumerable<ExamListDTO>>(_repo.GetAll(includes: new string[] { "Student", "Lesson" })); //.Include(x=> x.AppUser)
        public async Task<ExamDetailDTO> GetByIdAsync(int id)
		{
			var data = await _checkId(id, true);
			return _mapper.Map<ExamDetailDTO>(data);
		}

		public async Task UpdateAsync(int id, ExamUpdateDTO dto)
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

        async Task<Exam> _checkId(int id, bool isTrack = false)
		{
			if (id <= 0) throw new ArgumentException();
			var data = await _repo.GetByIdAsync(id, isTrack, "Student");
			if (data == null) throw new NotFoundException<Exam>();
			return data;
		}
	}
}
