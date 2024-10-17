using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.DTOs.UserDTOs
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte? ClassNumber { get; set; }
        public string Role { get; set; }
    }
}
