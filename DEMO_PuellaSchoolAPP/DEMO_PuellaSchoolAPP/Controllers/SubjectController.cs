using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Classes;
using DEMO_PuellaSchoolAPP.Repositories.Grades;
using FluentValidation;
using Microsoft.Data.SqlClient;
using DEMO_PuellaSchoolAPP.Validations;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGradesRepository _gradeRepository;
        private readonly IValidator<SubjectModel> _validator;

        private SelectList _gradeList;

        public SubjectController(ISubjectRepository subjectRepository, IGradesRepository gradeRepository, IValidator<SubjectModel> validator)
        {
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
            _validator = validator;

            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            var grade = await _gradeRepository.GetAllAsync();
            _gradeList = new SelectList(
                grade,
                nameof(GradeModel.GradeId),
                nameof(GradeModel.GradeName)
            );

        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return View(subjects);
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // GET: Subject/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Grade = new SelectList(await _gradeRepository.GetAllAsync(), "GradeId", "GradeName");
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName,SubjectInfo,GradeId")] SubjectModel subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }

            try
            {
                var validationResult = await _validator.ValidateAsync(subject);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(subject);
                }

                await _subjectRepository.AddAsync(subject);
                TempData["message"] = "Datos guardados correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View(subject);
            }
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewBag.Grade = new SelectList(await _gradeRepository.GetAllAsync(), "GradeId", "GradeName", subject.GradeId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName,SubjectInfo,GradeId")] SubjectModel subject)
        {
            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(subject);
            }

            try
            {
                var validationResult = await _validator.ValidateAsync(subject);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(subject);
                }

                await _subjectRepository.EditAsync(subject);
                TempData["message"] = "Datos editados correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View(subject);
            }
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _subjectRepository.DeleteAsync(id);
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
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult ImportData()
        {
            return View();
        }

       
    }
}
