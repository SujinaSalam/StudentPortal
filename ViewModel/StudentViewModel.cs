using StudentPortal.Models;

namespace StudentPortal.ViewModel
{
    public class StudentViewModel
    {
        public IEnumerable<Student>? Students { get; set; }

        public Student? Student { get; set; }
        public string? SearchName { get; set; }

        public DateTime? SearchStartDate { get; set; }

        public DateTime? SearchEndDate { get; set; }
        public int CurrentPageIndex { get; set; } = 1;
        
        public int TotalPages { get; set; }

    }
}
