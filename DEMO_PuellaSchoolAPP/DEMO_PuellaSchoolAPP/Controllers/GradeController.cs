using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Grades;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradesRepository _gradesRepository;
        private readonly IValidator<GradeModel> _validator;

        public GradeController(IGradesRepository gradesRepository, IValidator<GradeModel> validator)
        {
            _gradesRepository = gradesRepository;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            var grades = await _gradesRepository.GetAllAsync();

            return View(grades);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GradeModel grades)
        {
            if (!ModelState.IsValid)
            {
                return View(grades);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(grades);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(grades);
                }

                await _gradesRepository.AddAsync(grades);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(grades);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var grades = await _gradesRepository.GetByIdAsync(id);

            if (grades == null)
                return NotFound();

            return View(grades);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GradeModel grades)
        {
            if (!ModelState.IsValid)
            {
                return View(grades);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(grades);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(grades);
                }

                await _gradesRepository.EditAsync(grades);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(grades);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var grades = await _gradesRepository.GetByIdAsync(id);

            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(GradeModel grades)
        {
            try
            {
                await _gradesRepository.DeleteAsync(grades.GradeId);

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
