using AutoMapper;
using ExamTask.Business.DTOs.ExamDTOs;
using ExamTask.Business.DTOs.LessonDTOs;
using ExamTask.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize(Roles = "Admin")]
    public class AdminExamController : Controller
    {
        readonly IExamService _examService;
        readonly ILessonService _lessonService;
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public AdminExamController(IExamService examService, IUserService userService, IMapper mapper, ILessonService lessonService)
        {
            _examService = examService;
            _userService = userService;
            _mapper = mapper;
            _lessonService = lessonService;
        }

        public IActionResult Index()
        {
            var dto = _examService.GetAll();
            return View(dto);
        }

        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Students = users.Where(u => u.Role == "Student")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            ViewBag.Lessons = _lessonService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExamCreateDTO dto)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Students = users.Where(u => u.Role == "Student")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            ViewBag.Lessons = _lessonService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var lesson = await _lessonService.GetByIdAsync(dto.LessonId);
            var student = await _userService.GetByIdAsync(dto.StudentId);

            if (student.ClassNumber != lesson.ClassNumber)
            {
                ModelState.AddModelError("", "The selected student is not in the same grade as the selected lesson's grade.");
                return View(dto);
            }

            try
            {
                await _examService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Students = users.Where(u => u.Role == "Student")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            ViewBag.Lessons = _lessonService.GetAll();
            var detailDto = await _examService.GetByIdAsync(id);
            var updateDto = _mapper.Map<ExamUpdateDTO>(detailDto);
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ExamUpdateDTO dto)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Students = users.Where(u => u.Role == "Student")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            ViewBag.Lessons = _lessonService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var lesson = await _lessonService.GetByIdAsync(dto.LessonId);
            var student = await _userService.GetByIdAsync(dto.StudentId);

            if (student.ClassNumber != lesson.ClassNumber)
            {
                ModelState.AddModelError("", "The selected student is not in the same grade as the selected lesson's grade.");
                return View(dto);
            }

            try
            {
                await _examService.UpdateAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _examService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
