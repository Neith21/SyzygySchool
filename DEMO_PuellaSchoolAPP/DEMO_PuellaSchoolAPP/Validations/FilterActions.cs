using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class FilterActions : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                var userName = user.FindFirstValue(ClaimTypes.Name);
                var email = user.FindFirstValue(ClaimTypes.Email);
                var rol = user.FindFirstValue(ClaimTypes.Role);

                var controller = context.Controller as Controller;
                if (controller != null)
                {
                    controller.ViewBag.UserName = userName;
                    controller.ViewBag.Email = email;
                    controller.ViewBag.Rol = rol;
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // vacio [No borrar]
        }
    }
}
