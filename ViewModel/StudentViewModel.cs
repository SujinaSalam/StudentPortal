using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{

    /// <summary>
    /// View model class used to bind the model class with view.
    /// </summary>
    public class StudentViewModel : IValidatableObject
    {
        public IEnumerable<Student>? Students { get; set; }

        public Student? Student { get; set; }
        public string? SearchName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SearchStartDate { get; set; }

        public DateTime? SearchEndDate { get; set; }
        public int CurrentPageIndex { get; set; } = 1;
        
        public int TotalPages { get; set; }

        /// <summary>
        /// Method to add validation for Date field.
        /// This method informs that the Start Date must be selected if an end date is selected.
        /// </summary>
        /// <param name="validationContext">Default validation context</param>
        /// <returns>An enumeration of ValidationResult.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SearchEndDate.HasValue && !SearchStartDate.HasValue)
            {
                yield return new ValidationResult("Start Date must be selected if you select end date", new[] { nameof(SearchStartDate) });
            }
        }
    }
}
