using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RClassrooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    [Authorize]
    public class ClassroomController : Controller
    {
        private readonly IClassroomsRepository _classroomsRepository;
        private SelectList _studentsList;

        public ClassroomController(IClassroomsRepository classroomsRepository)
        {
            _classroomsRepository = classroomsRepository;
            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            var subjects = await _classroomsRepository.GetAllStudents();
            _studentsList = new SelectList(
                subjects,
                nameof(StudentModel.StudentId),
                nameof(StudentModel.StudentName)
            );
        }

        public async Task<ActionResult> Index()
        {
            var clasrooms = await _classroomsRepository.GetAllAsync();

            return View(clasrooms);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Students = _studentsList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassroomModel classrooms)
        {
            try
            {
                await _classroomsRepository.AddAsync(classrooms);
                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Students = _studentsList;

                return View(classrooms);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var classrooms = await _classroomsRepository.GetByIdAsync(id);

            if (classrooms == null)
                return NotFound();

            var subjects = await _classroomsRepository.GetAllStudents();
            _studentsList = new SelectList(
                subjects,
                nameof(StudentModel.StudentId),
                nameof(StudentModel.StudentName)
            );
            ViewBag.Students = _studentsList;

            return View(classrooms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClassroomModel classrooms)
        {
            try
            {
                await _classroomsRepository.EditAsync(classrooms);
                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                ViewBag.Students = _studentsList;
                return View(classrooms);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var classrooms = await _classroomsRepository.GetByIdAsync(id);

            if (classrooms == null)
            {
                return NotFound();
            }

            return View(classrooms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ClassroomModel classrooms)
        {
            try
            {
                await _classroomsRepository.DeleteAsync(classrooms.ClassroomId);
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
