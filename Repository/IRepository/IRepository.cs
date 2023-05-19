using System.Linq.Expressions;

namespace StudentPortal.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(int pageSize, int pageNumber);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, int pageSize = 3, int pageNumber = 1);
    }
}
