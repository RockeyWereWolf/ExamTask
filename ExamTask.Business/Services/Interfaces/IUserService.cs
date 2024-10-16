using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Business.DTOs.AuthDTOs;

namespace ExamTask.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDTO dto);
    }
}
