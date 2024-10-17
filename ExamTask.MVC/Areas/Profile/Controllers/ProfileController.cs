using ExamTask.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = await _userService.GetByIdAsync(userId);
            return View(dto);
        }

        public async Task<IActionResult> Details()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = await _userService.GetByIdAsync(userId);
            return View(dto);
        }
    }
}
