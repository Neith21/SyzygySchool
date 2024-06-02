using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Sections;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionsRepository _sectionRepository;
        private readonly IValidator<SectionModel> _validator;

        public SectionController(ISectionsRepository sectionRepository, IValidator<SectionModel> validator)
        {
            _sectionRepository = sectionRepository;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            var sections = await _sectionRepository.GetAllAsync();

            return View(sections);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SectionModel sections)
        {
            if (!ModelState.IsValid)
            {
                return View(sections);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(sections);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(sections);
                }

                await _sectionRepository.AddAsync(sections);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(sections);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var sections = await _sectionRepository.GetByIdAsync(id);

            if (sections == null)
                return NotFound();

            return View(sections);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SectionModel sections)
        {
            if (!ModelState.IsValid)
            {
                return View(sections);
            }

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(sections);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(sections);
                }

                await _sectionRepository.EditAsync(sections);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(sections);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var sections = await _sectionRepository.GetByIdAsync(id);

            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SectionModel sections)
        {
            try
            {
                await _sectionRepository.DeleteAsync(sections.SectionId);

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
