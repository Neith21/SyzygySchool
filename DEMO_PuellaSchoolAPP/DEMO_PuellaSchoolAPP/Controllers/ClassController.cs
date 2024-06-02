using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Classes;
using DEMO_PuellaSchoolAPP.Repositories.Schedules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        private SelectList _gradeList;
        private SelectList _sectionList;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;

            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            var grades = await _classRepository.GetAllGradesAsync();
            _gradeList = new SelectList(
                grades,
                nameof(GradeModel.GradeId),
                nameof(GradeModel.GradeName)
            );

            var sections = await _classRepository.GetAllSectionsAsync();
            _sectionList = new SelectList(
                sections,
                nameof(SectionModel.SectionId),
                nameof(SectionModel.SectionName)
            );
        }

        public async Task<ActionResult> Index()
        {
            var classes = await _classRepository.GetAllAsync();

            return View(classes);
        }

		[HttpGet]
		public ActionResult ListClassroom()
		{
			
			return View();
		}

		[HttpGet]
        public ActionResult Create()
        {
            ViewBag.Grades = _gradeList;
            ViewBag.Sections = _sectionList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassModel classs)
        {
            try
            {
                await _classRepository.AddAsync(classs);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Grades = _gradeList;
                ViewBag.Sections = _sectionList;

                return View(classs);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var classes = await _classRepository.GetByIdAsync(id);

            if (classes == null)
                return NotFound();

            var grades = await _classRepository.GetAllGradesAsync();
            _gradeList = new SelectList(
                grades,
                nameof(GradeModel.GradeId),
                nameof(GradeModel.GradeName)
            );

            var sections = await _classRepository.GetAllSectionsAsync();
            _sectionList = new SelectList(
                sections,
                nameof(SectionModel.SectionId),
                nameof(SectionModel.SectionName)
            );

            ViewBag.Grades = _gradeList;
            ViewBag.Sections = _sectionList;

            return View(classes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClassModel classs)
        {
            try
            {
                await _classRepository.EditAsync(classs);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Grades = _gradeList;
                ViewBag.Sections = _sectionList;

                return View(classs);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var classs = await _classRepository.GetByIdAsync(id);

            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ClassModel classs)
        {
            try
            {
                await _classRepository.DeleteAsync(classs.ClassId);

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
