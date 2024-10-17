using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Business.DTOs.AuthDTOs;
using ExamTask.Core.Entities;
using ExamTask.Business.DTOs.UserDTOs;

namespace ExamTask.Business.Profiles
{
	public class UserMappingProfile : Profile
	{
		public UserMappingProfile()
		{
			CreateMap<UserCreateDTO, AppUser>();
			CreateMap<UserUpdateDTO, AppUser>();
			CreateMap<AppUser, UserListDTO>();
			CreateMap<AppUser, UserDetailDTO>();
			CreateMap<UserDetailDTO, UserUpdateDTO>();
		}
	}
}
