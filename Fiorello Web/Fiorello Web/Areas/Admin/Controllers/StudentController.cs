using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;   
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAdminAsync();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            await _studentService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var student = await _studentService.GetByID(id.Value);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
