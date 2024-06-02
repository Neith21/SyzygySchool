using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using FluentValidation;
using DEMO_PuellaSchoolAPP.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IValidator<StudentModel> _validator;

        public StudentController(IStudentsRepository studentsRepository, IValidator<StudentModel> validator)
        {
            _studentsRepository = studentsRepository;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {

            var students = await _studentsRepository.GetAllAsync();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentModel students)
        {
            if (!ModelState.IsValid)
            {
                return View(students);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(students);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(students);
                }

                await _studentsRepository.AddAsync(students);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(students);
            }
        }

		[HttpGet]
		public IActionResult ImportData()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> ImportData(IFormFile file)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(directoryPath, fileName);

                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    await _studentsRepository.ImportDataAsync(path);

                    TempData["message"] = "Los datos se importaron exitosamente.";
                }
                catch (Exception ex)
                {
                    TempData["message"] = $"Ocurrió un error durante la importación de datos: {ex.Message}";
                }
            }
            else
            {
                TempData["message"] = "Por favor, selecciona un archivo antes de enviar.";
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var students = await _studentsRepository.GetByIdAsync(id);

            if (students == null)
                return NotFound();

            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentModel students)
        {
            if (!ModelState.IsValid)
            {
                return View(students);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(students);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(students);
                }

                await _studentsRepository.EditAsync(students);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(students);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentsRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(StudentModel students)
        {
            try
            {
                 await _studentsRepository.DeleteAsync(students.StudentId);

                TempData["message"] = "Datos eliminados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View();
            }
        }
    }
}
