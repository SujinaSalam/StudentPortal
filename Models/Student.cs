using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    /// <summary>
    /// Class for holding the student details.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public int Age { get; set;}
        public DateTime EnrolledDate { get; set;}
    }
}
