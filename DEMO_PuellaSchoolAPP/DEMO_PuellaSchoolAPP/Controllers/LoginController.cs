using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Logins;
using DEMO_PuellaSchoolAPP.Repositories.Roles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using DEMO_PuellaSchoolAPP.Repositories.RTeachers;

namespace DEMO_PuellaSchoolAPP.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly ITeacherRepository _teacherRepository;
        //private readonly IValidator<LoginModel> _validator;

        public LoginController(ILoginRepository loginRepository, IRolesRepository rolesRepository, ITeacherRepository teacherRepository/*, IValidator<LoginModel> validator*/)
        {
            _loginRepository = loginRepository;
            _rolesRepository = rolesRepository;
            _teacherRepository = teacherRepository;
            /*_validator = validator;*/
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var logins = await _loginRepository.GetAllAsync();

            return View(logins);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel loginModel)
        {
            try
            {

                await _loginRepository.AddAsync(loginModel);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(loginModel);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var login = await _loginRepository.GetByIdAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LoginModel loginModel)
        {
            try
            {

                await _loginRepository.EditAsync(loginModel);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(loginModel);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var login = await _loginRepository.GetByIdAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(LoginModel loginModel)
        {
            try
            {
                await _loginRepository.DeleteAsync(loginModel.LoginId);

                TempData["message"] = "Datos eliminados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View();
            }
        }


        public ActionResult Login()
        {
            ClaimsPrincipal claimsUsuario = HttpContext.User;
            if (claimsUsuario.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            var credentialsList = await _loginRepository.GetAllAsync();
            var credential = credentialsList.FirstOrDefault(c => c.LoginUser == loginModel.LoginUser && c.LoginPassword == loginModel.LoginPassword);
            var roles = await _rolesRepository.GetAllAsync();
            var teachers = await _teacherRepository.GetAllAsync();

            if (credential != null)
            {
                credential.Roles = roles.FirstOrDefault(r => r.RoleId == credential.RoleId);
                credential.Teacher = teachers.FirstOrDefault(t => t.TeacherId == credential.TeacherId);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, credential.Teacher.TeacherName + " " + credential.Teacher.TeacherLastName),
                    new Claim(ClaimTypes.Role, credential.Roles.RoleName),
                    new Claim(ClaimTypes.Email, credential.Teacher.TeacherEmail)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["messageLogin"] = "Usuario o Contraseña Incorrectos, Vuelva a Intentarlo";
            }

            return View(loginModel);
        }

        public ActionResult RestorePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RestorePassword(LoginModel loginModel)
        {
            var credentials = await _loginRepository.GetAllAsync();
            var credential = credentials.FirstOrDefault(c => c.LoginUser == loginModel.LoginUser);

            if (credentials != null)
            {
                var teachersList = await _teacherRepository.GetAllAsync();
                var teacher = teachersList.FirstOrDefault(t => t.TeacherEmail == loginModel.Teacher.TeacherEmail);

                if (teacher != null && credential != null && credential?.TeacherId == teacher?.TeacherId)
                {
                    credential.LoginPassword = loginModel.LoginPassword;

                    await _loginRepository.EditAsync(credential);

                    TempData["messageLogin"] = "Contraseña restaurada correctamente.";

                    return RedirectToAction("Login", "Login");
                }
                TempData["messageRestorePassword"] = "Usuario no encontrado, Vuelva a Intentarlo";
            }
            else
            {
                TempData["messageRestorePassword"] = "Usuario no encontrado, Vuelva a Intentarlo";
            }
            return View(loginModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
