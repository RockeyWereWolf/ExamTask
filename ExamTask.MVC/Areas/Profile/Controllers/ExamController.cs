using AutoMapper;
using ExamTask.Business.DTOs.ExamDTOs;
using ExamTask.Business.Services.Implements;
using ExamTask.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize]
    public class ExamController : Controller
    {
        readonly IExamService _examService;
        readonly IUserService _userService;
        readonly ILessonService _lessonService;
        readonly IMapper _mapper;

        public ExamController(IExamService examService, IUserService userService, IMapper mapper, ILessonService lessonService)
        {
            _examService = examService;
            _userService = userService;
            _mapper = mapper;
            _lessonService = lessonService;
        }
        [Authorize(Roles = "Student")]
        public IActionResult StudentIndex()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var examDtos = _examService.GetAll().Where(e => e.StudentId == userId);
            return View(examDtos);
        }
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> TeacherIndex()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userDto = await _userService.GetByIdAsync(userId);
            var userLessons = _lessonService.GetAll().Where(l => l.TeacherId == userId);
            var examDtos = _examService.GetAll().Where(e => userLessons.Any(l => l.Id == e.LessonId));
            return View(examDtos);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateScore(int examId, byte grade)
        {
            var examDetailDto = await _examService.GetByIdAsync(examId);

            var examUpdateDto = _mapper.Map<ExamUpdateDTO>(examDetailDto);

            examUpdateDto.Grade = grade;

            try
            {
                // Reuse the existing UpdateAsync method
                await _examService.UpdateAsync(examId, examUpdateDto);
                return RedirectToAction(nameof(TeacherIndex)); // Refresh the page
            }
            catch (Exception ex)
            {
                // Handle any errors
                return BadRequest(ex.Message);
            }
        }

    }
}
