using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ExamTask.Core.Entities.Common;

namespace ExamTask.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll(bool notTracked = true, params string[] includes);
		Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes);
		Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
		Task CreateAsync(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
