using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Service;
using StudentPortal.ViewModel;
using System.Diagnostics;

namespace StudentPortal.Controllers
{
    /// <summary>
    /// Class for student controller.
    /// </summary>
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        private readonly StudentService _studentService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="studentService">The object service class.</param>
        /// <param name="logger">The logger object.</param>
        public StudentController(StudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        /// <summary>
        /// Method to get the list of the students.
        /// </summary>
        /// <param name="viewModel">View model object to bind between the view and the model.</param>
        /// <returns>The list of students.</returns>
        public IActionResult Students(StudentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewmodel = _studentService.GetStudents(viewModel);
                    return View(viewmodel.Result);
                }

                return View();
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while processing the Students.");
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }
        }

        /// <summary>
        /// Method to get the list of the students.
        /// </summary>
        /// <param name="viewModel">View model object to bind between the view and the model.</param>
        /// <returns>The list of students.</returns>
        [HttpPost]
        public ActionResult GetSearchResults(StudentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewmodel = _studentService.GetStudents(viewModel);
                    return PartialView("_Students", viewmodel.Result.Students);
                }

                return PartialView("_Students");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the Students.");
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }
        }

        /// <summary>
        /// Method to display the error.
        /// </summary>
        /// <returns>The error details.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}