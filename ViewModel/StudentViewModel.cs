using StudentPortal.Models;

namespace StudentPortal.ViewModel
{
    public class StudentViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Student>? Students { get; set; }
        public string? SearchName { get; set; }

        public DateTime? SearchStartDate { get; set; }

        public DateTime? SearchEndDate { get; set; }

        public string? OrderBy { get; set; }

        public int PageIndex { get; set; }
    }
}
