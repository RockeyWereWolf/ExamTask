using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.Exceptions.AppUser
{
    public class AppUserUpdateFailedException : Exception
    {
        public AppUserUpdateFailedException() : base() { }

        public AppUserUpdateFailedException(string message) : base(message) { }
    }
}
