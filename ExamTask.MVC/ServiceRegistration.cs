using Microsoft.AspNetCore.Identity;
using ExamTask.Core.Entities;
using ExamTask.DAL.Contexts;

namespace ExamTask.MVC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ExamContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            return services;
        }
    }
}
