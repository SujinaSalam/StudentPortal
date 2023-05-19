using StudentPortal.Repository.IRepository;
using System.Linq.Expressions;

namespace StudentPortal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public List<T> DataSet { set; get; }
       
        public Task<List<T>> GetAllAsync(int pageSize, int pageNumber)
        {
            return GetPageResult(DataSet, pageSize, pageNumber);
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, int pageSize, int pageNumber)
        {
            if(predicate != null)
            {
                IQueryable<T> query = DataSet.AsQueryable();
                var searchResult = query.Where(predicate).ToList(); // Check what happens if the result is null
                return GetPageResult(searchResult, pageSize, pageNumber);
            }
            return GetPageResult(DataSet, pageSize, pageNumber); // If predicate is null we can return the objects
        }

        private Task<List<T>> GetPageResult(List<T> dataSet, int pageSize, int pageNumber)
        {
            if(dataSet == null)
            {
                return Task.FromException<List<T>>(
                    new ArgumentNullException(nameof(dataSet), "dataSet is null for pagination"));
            }
            if(dataSet.Count > pageSize)
            {
                int totalCount = dataSet.Count;
                int numberOfPages = (int)Math.Ceiling((double)totalCount / pageSize);
                dataSet.Skip(pageNumber * pageSize).Take(pageSize);
                return Task.FromResult(dataSet);
            }
            return Task.FromResult(dataSet);
        }
    }
}
