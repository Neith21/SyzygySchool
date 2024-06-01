using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using FluentValidation;
using DEMO_PuellaSchoolAPP.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Controllers
{
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

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(students);
            }
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

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
