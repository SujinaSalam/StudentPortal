using StudentPortal.Models;
using StudentPortal.Models.DTO;
using StudentPortal.Repository.IRepository;
using StudentPortal.ViewModel;
using System.Linq;

namespace StudentPortal.Service
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentViewModel _studentViewModel;
        public StudentService(StudentRepository studentRepository,StudentViewModel studentViewModel)
        {
            _studentRepository = studentRepository;
            _studentViewModel = studentViewModel;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentViewModel"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public Task<StudentViewModel> GetStudentsBySearchName(StudentViewModel studentViewModel, int pageSize, int pageNumber)
        {
            var studentlist = _studentRepository.GetAsync(
                 stu => ((stu.FirstName.Contains(studentViewModel.SearchName, StringComparison.OrdinalIgnoreCase) ||
                 stu.LastName.Contains(studentViewModel.SearchName, StringComparison.OrdinalIgnoreCase)) &&
                 (stu.EnrolledDate >= studentViewModel.SearchStartDate && stu.EnrolledDate <= studentViewModel.SearchEndDate)),
                 studentViewModel.PageIndex, pageSize);

            studentViewModel.Students = studentlist.GetStudentsOrderByDate
            _studentRepository.GetAllAsync(pageSize, pageNumber);
            return null;
        }

        public Task<StudentViewModel> GetStudentsOrderByDate(StudentViewModel studentViewModel)
        {


            return studentViewModel.Students.OrderBy(stu => stu.EnrolledDate);

        }
    }
}
