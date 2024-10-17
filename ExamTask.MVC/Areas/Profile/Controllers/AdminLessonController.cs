using AutoMapper;
using ExamTask.Business.DTOs.LessonDTOs;
using ExamTask.Business.DTOs.UserDTOs;
using ExamTask.Business.Exceptions.AppUser;
using ExamTask.Business.Services.Implements;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize(Roles = "Admin")]
    public class AdminLessonController : Controller
    {
        readonly ILessonService _lessonService;
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public AdminLessonController(ILessonService lessonService, IUserService userService, IMapper mapper)
        {
            _lessonService = lessonService;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var dto = _lessonService.GetAll();
            return View(dto);
        }

        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Teachers = users.Where(u => u.Role == "Teacher")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}" 
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LessonCreateDTO dto)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Teachers = users.Where(u => u.Role == "Teacher")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _lessonService.CreateAsync(dto);
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
            ViewBag.Teachers = users.Where(u => u.Role == "Teacher")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            var detailDto = await _lessonService.GetByIdAsync(id);
            var updateDto = _mapper.Map<LessonUpdateDTO>(detailDto);
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, LessonUpdateDTO dto)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.Teachers = users.Where(u => u.Role == "Teacher")
            .Select(t => new
            {
                Id = t.Id,
                DisplayName = $"{t.Name} {t.Surname}"
            });
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _lessonService.UpdateAsync(id, dto);
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
            await _lessonService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
