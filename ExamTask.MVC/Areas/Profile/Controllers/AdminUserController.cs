using AutoMapper;
using ExamTask.Business.DTOs.UserDTOs;
using ExamTask.Business.Exceptions.AppUser;
using ExamTask.Business.Exceptions.Auth;
using ExamTask.Business.Services.Implements;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Controllers;
using ExamTask.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    public class AdminUserController : Controller
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public AdminUserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dto = await _userService.GetAllAsync();
            return View(dto);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(UserCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            dto.Role = nameof(Roles.Student);
            try
            {
                await _userService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (AppUserCreationFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> UpdateStudent(string id)
        {
            var detailDto = await _userService.GetByIdAsync(id);
            var updateDto = _mapper.Map<UserUpdateDTO>(detailDto);
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(string id, UserUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _userService.UpdateAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (AppUserUpdateFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(UserCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            dto.Role = nameof(Roles.Teacher);
            try
            {
                await _userService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (AppUserCreationFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> UpdateTeacher(string id)
        {
            var detailDto = await _userService.GetByIdAsync(id);
            var updateDto = _mapper.Map<UserUpdateDTO>(detailDto);
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(string id, UserUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _userService.UpdateAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (AppUserUpdateFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> UpdateAdmin(string id)
        {
            var detailDto = await _userService.GetByIdAsync(id);
            var updateDto = _mapper.Map<UserUpdateDTO>(detailDto);
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(string id, UserUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _userService.UpdateAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (AppUserUpdateFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
