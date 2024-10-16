using Microsoft.AspNetCore.Identity;
using ExamTask.Business.DTOs.AuthDTOs;
using ExamTask.Business.Exceptions.Auth;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamTask.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Login(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail) ?? await _userManager.FindByNameAsync(dto.UsernameOrEmail);   /*await userManager.FindByNameAsync(credentials.Username);*/
            if (user == null) throw new LoginFailedException("Login failed. Check your credentials!");

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, true);
            if (!result.Succeeded) throw new LoginFailedException("Login failed. Check your credentials!");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
