using ExamTask.Business.Repositories.Interfaces;
using ExamTask.Core.Entities;
using ExamTask.DAL.Contexts;

namespace ExamTask.Business.Repositories.Implements
{
	public class ExamRepository : GenericRepository<Exam>, IExamRepository
	{
		public ExamRepository(ExamContext context) : base(context)
		{
		}
	}
}
