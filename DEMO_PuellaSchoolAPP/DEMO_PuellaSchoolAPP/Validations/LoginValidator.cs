using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;
namespace DEMO_PuellaSchoolAPP.Validations
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.LoginUser)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio")
                .Length(3, 50).WithMessage("El nombre de usuario debe tener entre 3 y 50 caracteres");

            RuleFor(x => x.LoginPassword)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .Length(8, 100).WithMessage("La contraseña debe tener entre 8 y 100 caracteres");

            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("El ID del docente es obligatorio")
                .GreaterThan(0).WithMessage("El ID del docente debe ser un número positivo");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("El ID del rol es obligatorio")
                .GreaterThan(0).WithMessage("El ID del rol debe ser un número positivo");
        }
    }
}
