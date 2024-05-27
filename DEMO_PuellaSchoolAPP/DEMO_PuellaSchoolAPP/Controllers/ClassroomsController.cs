    using DEMO_PuellaSchoolAPP.Models;
    using DEMO_PuellaSchoolAPP.Repositories.RClassrooms;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace DEMO_PuellaSchoolAPP.Controllers
    {
        public class ClassroomsController : Controller
        {
            private readonly IClassroomsRepository _classroomsRepository;
            private SelectList _studentsList;

            public ClassroomsController(IClassroomsRepository classroomsRepository)
            {
                _classroomsRepository = classroomsRepository;
                
            }

            public async Task<ActionResult> Index()
            {
                var clasrooms = await _classroomsRepository.GetAllAsync();
                _studentsList = new SelectList(
                                    await _classroomsRepository.GetAllStudents(),
                                    nameof(StudentsModel.StudentId),
                                    nameof(StudentsModel.StudentName)
                    );

                return View(clasrooms);
            }

            [HttpGet]
            public ActionResult Create()
            {
                ViewBag.TheStudent = _studentsList;
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(ClassroomsModel classrooms)
            {
                try
                {
                    await _classroomsRepository.AddAsync(classrooms);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                    ViewBag.TheStudent = _studentsList;

                    return View(classrooms);
                }
            }

            [HttpGet]
            public async Task<ActionResult> Edit(int id)
            {
                var classrooms = await _classroomsRepository.GetByIdAsync(id);

                if (classrooms == null)
                    return NotFound();

                _studentsList = new SelectList(
                                        await _classroomsRepository.GetAllStudents(),
                                        nameof(StudentsModel.StudentId),
                                        nameof(StudentsModel.StudentName),
                                        classrooms?.Students?.StudentId
                    );


                return View(classrooms);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(ClassroomsModel classrooms)
            {
                try
                {
                    await _classroomsRepository.EditAsync(classrooms);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.TheStudent = _studentsList;
                    ViewBag.Error = ex.Message;
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
            public async Task<ActionResult> Delete(ClassroomsModel classrooms)
            {
                try
                {
                    await _classroomsRepository.DeleteAsync(classrooms.ClassroomId);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }
