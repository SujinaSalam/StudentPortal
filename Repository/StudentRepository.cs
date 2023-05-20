using StudentPortal.Models;
using StudentPortal.Repository.IRepository;

namespace StudentPortal.Repository
{
    /// <summary>
    /// Repository class for student model which is implementing interface for student repository
    /// </summary>
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
    }
}
