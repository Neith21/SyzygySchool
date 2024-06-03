using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Services.EMail;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using DEMO_PuellaSchoolAPP.Repositories.Schedules;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DEMO_PuellaSchoolAPP.Repositories.RTeachers;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IEMailService _emailService;

        private SelectList _subjectList;
        private SelectList _teacherList;
        private SelectList _classList;

        public ScheduleController(IScheduleRepository scheduleRepository, IEMailService emailService, ITeacherRepository teacherRepository)
        {
            _emailService = emailService;
            _scheduleRepository = scheduleRepository;
            _teacherRepository = teacherRepository;

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
            var classes = await _scheduleRepository.GetAllClassAsync();
            _classList = new SelectList(
                classes,
                nameof(ClassModel.ClassId),
                nameof(ClassModel.ClassInfo)
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
            ViewBag.Classes = _classList;

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ScheduleModel schedule)
		{
			try
			{
				await _scheduleRepository.AddAsync(schedule);


                var Teachers = await _teacherRepository.GetAllAsync();
                var teacher = Teachers.FirstOrDefault(T => T.TeacherId == schedule.TeacherId);
				TempData["message"] = "Datos guardados correctamente.";

                string email = teacher.TeacherEmail;
                string subject = "¡Horario asignado!";
                string type = "Create";
                _emailService.SendEmail(email, teacher.TeacherName + " " + teacher.TeacherLastName, subject, type);

                return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

                ViewBag.Subjects = _subjectList;
                ViewBag.Teachers = _teacherList;
                ViewBag.Classes = _classList;

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
            var classes = await _scheduleRepository.GetAllClassAsync();
            _classList = new SelectList(
                classes,
                nameof(ClassModel.ClassId),
                nameof(ClassModel.ClassInfo)
            );

            ViewBag.Subjects = _subjectList;
            ViewBag.Teachers = _teacherList;
            ViewBag.Classes = _classList;

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

				var Teachers = await _teacherRepository.GetAllAsync();
				var teacher = Teachers.FirstOrDefault(T => T.TeacherId == schedule.TeacherId);
				TempData["message"] = "Datos guardados correctamente.";

				string email = teacher.TeacherEmail;
				string subject = "¡Horario asignado!";
				string type = "Edit";
				_emailService.SendEmail(email, teacher.TeacherName + " " + teacher.TeacherLastName, subject, type);

				return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Subjects = _subjectList;
                ViewBag.Teachers = _teacherList;
                ViewBag.Classes = _classList;

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
