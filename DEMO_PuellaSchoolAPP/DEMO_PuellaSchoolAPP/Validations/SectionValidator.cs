using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class SectionValidator : AbstractValidator<SectionModel>
    {
        public SectionValidator()
        {
            RuleFor(x => x.SectionName)
                .Matches(@"^[^{}<>]*$").WithMessage("La sección no puede contener { o } o < o >")
                .MaximumLength(50).WithMessage("El nombre de la sección no puede exceder 50 caracteres");

            RuleFor(x => x.SectionInfo)
                .Matches(@"^[^{}<>]*$").WithMessage("El grado no puede contener { o } o < o >")
                .MaximumLength(100).WithMessage("La información de la sección no puede exceder 100 caracteres");
        }
    }
}
