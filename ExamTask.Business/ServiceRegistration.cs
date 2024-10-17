using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Business.Profiles;
using ExamTask.Business.Repositories.Implements;
using ExamTask.Business.Repositories.Interfaces;
using ExamTask.Business.Services.Implements;
using ExamTask.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using ExamTask.Business.DTOs.AuthDTOs;
using static ExamTask.Business.DTOs.UserDTOs.UserCreateDTO;

namespace ExamTask.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<ILessonRepository, LessonRepository>();
			services.AddScoped<IExamRepository, ExamRepository>();
			return services;
        }
        public static IServiceCollection AddServices (this IServiceCollection services)
        {
			services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddBusinessLayer (this IServiceCollection services)
        {
			services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserCreateDTOValidator>());
			services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
			return services;
        }
    }
}
