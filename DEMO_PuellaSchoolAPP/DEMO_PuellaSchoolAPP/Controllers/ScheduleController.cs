using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using DEMO_PuellaSchoolAPP.Repositories.Schedules;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;

        private SelectList _subjectList;
        private SelectList _teacherList;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;

            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            var subjects = await _scheduleRepository.GetAllSubjectAsync();
            _subjectList = new SelectList(
                subjects,
                nameof(SubjectModel.SubjectId),
                nameof(SubjectModel.SubjectName)
            );

            var teachers = await _scheduleRepository.GetAllTeacherAsync();
            _teacherList = new SelectList(
                teachers,
                nameof(TeacherModel.TeacherId),
                nameof(TeacherModel.TeacherName)
            );
        }

        public async Task<ActionResult> Index()
        {
            var schedules = await _scheduleRepository.GetAllAsync();

            return View(schedules);
        }

		[HttpGet]
		public ActionResult Create()
		{
            ViewBag.Subjects = _subjectList;
            ViewBag.Teachers = _teacherList;

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ScheduleModel schedule)
		{
			try
			{
				await _scheduleRepository.AddAsync(schedule);

				TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

                ViewBag.Subjects = _subjectList;
                ViewBag.Teachers = _teacherList;

                return View(schedule);
			}
		}

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var schedules = await _scheduleRepository.GetByIdAsync(id);

            if (schedules == null)
                return NotFound();

            var subjects = await _scheduleRepository.GetAllSubjectAsync();
            _subjectList = new SelectList(
                subjects,
                nameof(SubjectModel.SubjectId),
                nameof(SubjectModel.SubjectName)
            );

            var teachers = await _scheduleRepository.GetAllTeacherAsync();
            _teacherList = new SelectList(
                teachers,
                nameof(TeacherModel.TeacherId),
                nameof(TeacherModel.TeacherName)
            );

            ViewBag.Subjects = _subjectList;
            ViewBag.Teachers = _teacherList;

            return View(schedules);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ScheduleModel schedule)
        {
            try
            {
                await _scheduleRepository.EditAsync(schedule);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Subjects = _subjectList;
                ViewBag.Teachers = _teacherList;

                return View(schedule);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ScheduleModel schedule)
        {
            try
            {
                await _scheduleRepository.DeleteAsync(schedule.IdSchedule);

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
