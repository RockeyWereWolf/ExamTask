using ExamTask.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize]
    public class LessonController : Controller
    {
        readonly ILessonService _lessonService;
        readonly IUserService _userService;

        public LessonController(ILessonService lessonService, IUserService userService)
        {
            _lessonService = lessonService;
            _userService = userService;
        }
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentIndex()
        {
            var userDto = await _userService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _lessonService.GetAll().Where(l => l.ClassNumber == userDto.ClassNumber);
            return View(dto);
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult TeacherIndex()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = _lessonService.GetAll().Where(l => l.TeacherId == userId);
            return View(dto);
        }
    }
}
