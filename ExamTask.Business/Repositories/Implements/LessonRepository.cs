using ExamTask.Business.Repositories.Interfaces;
using ExamTask.Core.Entities;
using ExamTask.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Business.Repositories.Implements
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(ExamContext context) : base(context)
        {
        }
    }
}
