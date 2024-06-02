using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Roles;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.Security.Claims;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    [Authorize]
    public class RolController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IValidator<RolModel> _validator;

        public RolController(IRolesRepository rolesRepository, IValidator<RolModel> validator)
        {
            _rolesRepository = rolesRepository;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {

            var logins = await _rolesRepository.GetAllAsync();

            return View(logins);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RolModel rolModel)
        {

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(rolModel);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(rolModel);
                }

                await _rolesRepository.AddAsync(rolModel);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(rolModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var rol = await _rolesRepository.GetByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RolModel rolModel)
        {
            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(rolModel);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);
                    return View(rolModel);
                }

                await _rolesRepository.EditAsync(rolModel);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(rolModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var login = await _rolesRepository.GetByIdAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(RolModel rolModel)
        {
            try
            {
                await _rolesRepository.DeleteAsync(rolModel.RoleId);

                TempData["message"] = "Datos eliminados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(rolModel);
            }
        }
    }
}
