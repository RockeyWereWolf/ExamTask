using ExamTask.Business.DTOs.AuthDTOs;
using ExamTask.Core.Entities;
using ExamTask.Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExamTask.Business.Exceptions.Roles;
using ExamTask.Business.Exceptions.AppUser;
using ExamTask.Business.Exceptions.Auth;

namespace ExamTask.Controllers
{
    public class AuthController : Controller
    {
        readonly IMapper _mapper;
        readonly IUserService _userService;
        readonly IAuthService _authService;

        public AuthController(IMapper mapper, IUserService userService, IAuthService authService)
        {
            _mapper = mapper;
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _authService.Login(dto);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch (LoginFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
