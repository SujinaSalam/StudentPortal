using StudentPortal.Repository.IRepository;
using System.Data;
using System.Linq.Expressions;

namespace StudentPortal.Repository
{
    /// <summary>
    /// Base repository class which is implementing IRepository interface.
    /// </summary>
    /// <typeparam name="T">Model class type.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private static List<T> DataSet { set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Repository() 
        {
            DataSet = new List<T>();
        }

        /// <summary>
        /// Method for getting the model objects satisfying the input query parameters.
        /// </summary>
        /// <param name="pageSize">The number of rows in a single page.</param>
        /// <param name="pageNumber">The current page number to be displayed.</param>
        /// <param name="searchpredicate">The search query.</param>
        /// <param name="sortpredicate">The sort query.</param>
        /// <param name="pageCount">The number of pages returned after query execution.</param>
        /// <returns>The list of model objects.</returns>
        public Task<List<T>> GetAsync(int pageSize,
                                      int pageNumber,
                                      Expression<Func<T, bool>> searchpredicate,
                                      Expression<Func<T, object>> sortpredicate,
                                      out int pageCount)
        {
            try
            {
                IQueryable<T> query = DataSet.AsQueryable();

                if (searchpredicate != null)
                {
                    query = query.Where(searchpredicate);
                }

                if (sortpredicate != null)
                {
                    query = query.OrderBy(sortpredicate);
                }


                var totalCount = query.Count();
                pageCount = (int)Math.Ceiling((decimal)(totalCount) / Convert.ToDecimal(pageSize));

                var searchResults = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                return Task.FromResult(searchResults);
            }
            catch (Exception ex)
            {
                pageCount = 0;
                throw new Exception("An error occurred while retrieving data.", ex);
            }
        }

        /// <summary>
        /// Method for adding data to datasource.
        /// </summary>
        /// <param name="model">Model type.</param>
        /// <returns>Task status.</returns>
        public Task CreateAsync(T model)
        {
            try
            {
                if (model != null)
                {
                    DataSet.Add(model);
                    return Task.CompletedTask;
                }
                return Task.FromException<ArgumentNullException>(new ArgumentNullException(nameof(model)));

            }
            catch(Exception ex) 
            {
                throw new Exception("An error occurred while retrieving data.", ex);
            }        
        }
    }
}
