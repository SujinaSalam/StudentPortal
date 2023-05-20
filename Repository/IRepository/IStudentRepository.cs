using StudentPortal.Models;

namespace StudentPortal.Repository.IRepository
{
    /// <summary>
    /// Interface class for student repository.
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        // If anything specific to student model, those methods/properties can be declared here.
    }
}
