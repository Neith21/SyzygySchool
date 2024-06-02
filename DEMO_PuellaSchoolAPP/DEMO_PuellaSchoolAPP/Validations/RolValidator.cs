using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;
namespace DEMO_PuellaSchoolAPP.Validations
{
    public class RolValidator : AbstractValidator<RolModel>
    {
        public RolValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio")
                .Length(2, 100).WithMessage("El nombre del rol debe tener entre 2 y 100 caracteres")
                .Matches(@"^[a-zA-ZñÑ0-9\s]+$").WithMessage("El nombre del rol solo puede contener letras, números y espacios");

            RuleFor(x => x.RoleInfo)
                .NotEmpty().WithMessage("La información del rol es obligatoria")
                .Length(5, 100).WithMessage("La información del rol debe tener entre 5 y 100 caracteres")
                .Matches(@"^[a-zA-ZñÑ0-9\s.,:!?()-]+$").WithMessage("La información del rol contiene caracteres inválidos");
        }
    }
}
