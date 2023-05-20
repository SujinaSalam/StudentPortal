using StudentPortal.Helpers;
using StudentPortal.Models;
using StudentPortal.Repository.IRepository;
using StudentPortal.ViewModel;
using System.Linq.Expressions;

namespace StudentPortal.Service
{
    /// <summary>
    /// Service class for controller class for interacting with repository.
    /// </summary>
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly int _pageSize;
        public StudentService(IConfiguration configuration, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _pageSize = configuration.GetPageSize();
            FillDummyData();
        }


        /// <summary>
        /// Method for getting the list of students.
        /// </summary>
        /// <param name="studentViewModel">View model class object used to bind the view with the student model.</param>
        /// <returns>StudentViewModel object.</returns>
        public Task<StudentViewModel> GetStudents(StudentViewModel studentViewModel)
        {
            try
            {
                Expression<Func<Student, bool>> queryExp = GetStudentFilterExpression(studentViewModel);
                Expression<Func<Student, object>> sortExp = (s) => s.EnrolledDate;
                int totalPages = 0;
                var studentlist = _studentRepository.GetAsync(_pageSize,
                     studentViewModel.CurrentPageIndex, queryExp, sortExp, out totalPages);

                studentViewModel.Students = studentlist.Result;
                studentViewModel.TotalPages = totalPages;
                return Task.FromResult(studentViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving student data.", ex);
            }
        }

        /// <summary>
        /// Method for creating the student objects.
        /// </summary>
        /// <param name="studentViewModel">View model class object which holds the student model.</param>
        /// <returns>The status of task.</returns>
        public Task CreateStudent(StudentViewModel studentViewModel)
        {
            try
            {
                if (studentViewModel.Student != null)
                {
                    return _studentRepository.CreateAsync(studentViewModel.Student);
                }

                return Task.FromException(new ArgumentNullException(nameof(studentViewModel.Student)));
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while adding student data.", ex);
            }
        }

        /// <summary>
        /// Method to prepare the query expression.
        /// </summary>
        /// <param name="studentViewModel">The object contains the search query paramters.</param>
        /// <returns>The query expression.</returns>
        private Expression<Func<Student, bool>> GetStudentFilterExpression(StudentViewModel studentViewModel)
        {
            try
            {
                Expression<Func<Student, bool>> query = (s) =>
                 (!string.IsNullOrEmpty(studentViewModel.SearchName) ? s.FirstName.Contains(studentViewModel.SearchName, StringComparison.CurrentCultureIgnoreCase) : true) ||
                 (!string.IsNullOrEmpty(studentViewModel.SearchName) ? s.LastName.Contains(studentViewModel.SearchName, StringComparison.CurrentCultureIgnoreCase) : true)
                && (studentViewModel.SearchStartDate.HasValue ? (s.EnrolledDate >= studentViewModel.SearchStartDate && s.EnrolledDate <= studentViewModel.SearchEndDate) : true);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while preparing student filter.", ex);
            }
        }

        /// <summary>
        /// Creates the dummy data.
        /// </summary>
        private void FillDummyData()
        {
            try
            {
                for (int i = 0; i < _pageSize; i++)
                {
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 1, FirstName = "MATHEW" + i, LastName = "Jordan", Age = 24, EnrolledDate = new DateTime(2018, 01, 02) } });
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 2, FirstName = "Jey" + i, LastName = "Marsh", Age = 26, EnrolledDate = new DateTime(2018, 02, 08) } });
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 3, FirstName = "Zeba" + i, LastName = "Elizabeth", Age = 34, EnrolledDate = new DateTime(2018, 01, 16) } });
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 4, FirstName = "John" + i, LastName = "Mathew", Age = 20, EnrolledDate = new DateTime(2018, 3, 01) } });
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 5, FirstName = "Cris" + i, LastName = "Colman", Age = 30, EnrolledDate = new DateTime(2018, 2, 27) } });
                    CreateStudent(new StudentViewModel() { Student = new Student { Id = i + 6, FirstName = "David" + i, LastName = "Maginnis", Age = 28, EnrolledDate = new DateTime(2018, 1, 31) } });
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while preparing student dummy data.", ex);
            }
        }
    }
}
