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

        public async Task CreateAsync(RegisterDTO dto)
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
            var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Student));
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
    }
}
