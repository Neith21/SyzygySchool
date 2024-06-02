using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using DEMO_PuellaSchoolAPP.Repositories.Schedules;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IValidator<ScheduleModel> _validator;

        private SelectList _subjectList;
        private SelectList _teacherList;

        public ScheduleController(IScheduleRepository scheduleRepository, IValidator<ScheduleModel> validator)
        {
            _scheduleRepository = scheduleRepository;
            _validator = validator;

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
				FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(schedule);

				if (!validationResult.IsValid)
				{
					validationResult.AddToModelState(ModelState);
					return View(schedule);
				}

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
	}
}
