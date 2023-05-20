using System.Linq.Expressions;

namespace StudentPortal.Repository.IRepository
{
    /// <summary>
    /// Interface for repository classes.
    /// </summary>
    /// <typeparam name="T">Type of model class.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Method for adding data to datasource.
        /// </summary>
        /// <param name="model">Model type.</param>
        /// <returns>Task status.</returns>
        Task CreateAsync(T model);

        /// <summary>
        /// Method for getting the model objects satisfying the input query parameters.
        /// </summary>
        /// <param name="pageSize">The number of rows in a single page.</param>
        /// <param name="pageNumber">The current page number to be displayed.</param>
        /// <param name="searchpredicate">The search query.</param>
        /// <param name="sortpredicate">The sort query.</param>
        /// <param name="pageCount">The number of pages returned after query execution.</param>
        /// <returns>The list of model objects.</returns>
        Task<List<T>> GetAsync(int pageSize,
                               int pageNumber,
                               Expression<Func<T, bool>> searchpredicate,
                               Expression<Func<T, object>> sortpredicate,
                               out int pageCount);
    }
}
