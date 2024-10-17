using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Business.DTOs.AuthDTOs;
using ExamTask.Business.Services.Interfaces;
using ExamTask.Core.Entities;
using ExamTask.Core.Enums;
using ExamTask.Business.Exceptions.Roles;
using ExamTask.Business.Exceptions.AppUser;
using ExamTask.Business.DTOs.UserDTOs;
using ExamTask.Business.Exceptions.Common;

namespace ExamTask.Business.Services.Implements
{
    public class UserService : IUserService
    {

        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;

        public UserService(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateAsync(UserCreateDTO dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new AppUserCreationFailedException(sb.ToString().TrimEnd());
            }
            var roleResult = await _userManager.AddToRoleAsync(user, dto.Role);
            if (!roleResult.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new RoleAssignFailedException(sb.ToString().TrimEnd());
            }
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _checkId(id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserListDTO>> GetAllAsync()
        {
            var users = _userManager.Users.ToList();
            var userListDTOs = new List<UserListDTO>();
            foreach (var user in users)
            {
                // Map the basic properties
                var userDto = _mapper.Map<UserListDTO>(user);

                // Retrieve roles asynchronously
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.FirstOrDefault(); // Assuming a single role

                userListDTOs.Add(userDto);
            }

            return userListDTOs;
        }

        public async Task<UserDetailDTO> GetByIdAsync(string id)
        {
            var user = await _checkId(id);
            return _mapper.Map<UserDetailDTO>(user);
        }

        public async Task ReverseSoftDelete(string id)
        {
            var user = await _checkId(id);
            user.IsDeleted = false;
            await _userManager.UpdateAsync(user);
        }

        public async Task SoftDelete(string id)
        {
            var user = await _checkId(id);
            user.IsDeleted = true;
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdateAsync(string id, UserUpdateDTO dto)
        {
            var data = await _checkId(id);
            data = _mapper.Map(dto, data);
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                var passwordValidator = _userManager.PasswordValidators.FirstOrDefault();
                var passwordResult = await passwordValidator.ValidateAsync(_userManager, data, dto.Password);
                if (!passwordResult.Succeeded)
                {
                    StringBuilder sb = new();
                    foreach (var error in passwordResult.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new AppUserUpdateFailedException(sb.ToString().TrimEnd());
                }
                var passwordHasher = new PasswordHasher<AppUser>();
                data.PasswordHash = passwordHasher.HashPassword(data, dto.Password);
            }
            var result = await _userManager.UpdateAsync(data);
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new AppUserUpdateFailedException(sb.ToString().TrimEnd());
            }
        }

        async Task<AppUser> _checkId(string id, bool isTrack = false)
        {
            var data = await _userManager.FindByIdAsync(id);
            if (data == null) throw new UserNotFoundException("User is not found");
            return data;
        }
    }
}
