using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class GradeValidator : AbstractValidator<GradeModel>
    {
        public GradeValidator() 
        {
            RuleFor(x => x.GradeName)
                .Matches(@"^[^{}<>]*$").WithMessage("El grado no puede contener { o } o < o >")
                .MaximumLength(50).WithMessage("El nombre del grado no puede exceder 50 caracteres");
        }
    }
}
