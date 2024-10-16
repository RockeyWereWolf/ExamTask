using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.Exceptions.Roles
{
    public class RolesCreationFailedException : Exception
    {
        public RolesCreationFailedException() : base() { }
        public RolesCreationFailedException(string message) : base(message) { }
    }
}
