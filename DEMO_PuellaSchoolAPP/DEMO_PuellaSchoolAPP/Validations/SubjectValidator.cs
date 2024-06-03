using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class SubjectValidator : AbstractValidator<SubjectModel>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.SubjectName)
                .Matches(@"^[^{}<>]*$").WithMessage("El nombre de la asignatura no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El nombre de la asignatura solo puede contener letras")
                .MaximumLength(25).WithMessage("El nombre de la asignatura no puede exceder 25 caracteres");

            RuleFor(x => x.SubjectInfo)
                .Matches(@"^[^{}<>]*$").WithMessage("La información de la asignatura no puede contener { o } o < o >")
                .MaximumLength(500).WithMessage("La información de la asignatura no puede exceder 500 caracteres");

            RuleFor(x => x.GradeId)
                .NotEmpty().WithMessage("El grado es obligatorio");
                
        }
    }
}
