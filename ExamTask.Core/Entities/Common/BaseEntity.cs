using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Core.Entities.Common
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
