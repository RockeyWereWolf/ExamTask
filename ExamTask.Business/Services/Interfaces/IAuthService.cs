using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Business.DTOs.AuthDTOs;
using ExamTask.Core.Entities;

namespace ExamTask.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task Login(LoginDTO dto);
        public Task Logout();
    }
}
