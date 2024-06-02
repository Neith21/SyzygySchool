using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RTeachers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DEMO_PuellaSchoolAPP.Validations;
using Microsoft.Data.SqlClient;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teachersRepository;
        private readonly IValidator<TeacherModel> _validator;

        public TeacherController(ITeacherRepository teachersRepository, IValidator<TeacherModel> validator)
        {
            _teachersRepository = teachersRepository;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            var teachers = await _teachersRepository.GetAllAsync();
            return View(teachers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            try
            {
               FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(teacher);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(teacher);
                }

                await _teachersRepository.AddAsync(teacher);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(teacher);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var teacher = await _teachersRepository.GetByIdAsync(id);

            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeacherModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(teacher);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(teacher);
                }

                await _teachersRepository.EditAsync(teacher);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(teacher);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await _teachersRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TeacherModel teacher)
        {
            try
            {
                await _teachersRepository.DeleteAsync(teacher.TeacherId);

                TempData["message"] = "Datos eliminados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (SqlException ex)
            {
                TempData["message"] = "No se puede eliminar el registro debido a restricciones de clave externa.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View();
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

                    await _teachersRepository.ImportDataAsync(path);

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
    }
}
