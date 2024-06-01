using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentName)
                .Matches(@"^[^{}<>]*$").WithMessage("El nombre del estudiante no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El nombre del estudiante solo puede contener letras")
                .MaximumLength(50).WithMessage("El nombre del estudiante no puede exceder 50 caracteres");

            RuleFor(x => x.StudentLastName)
                .Matches(@"^[^{}<>]*$").WithMessage("El apellido del estudiante no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El apellido del estudiante solo puede contener letras")
                .MaximumLength(50).WithMessage("El apellido del estudiante no puede exceder 50 caracteres");

            RuleFor(x => x.StudentAge)
                .Must(age => age is int).WithMessage("La edad de usuario debe ser un número entero válido")
                .InclusiveBetween(4, 95).WithMessage("La edad del estudiante debe estar entre 4 y 95");

            RuleFor(x => x.StudentGender)
                .Must(g => g == 'M' || g == 'F' || g == 'O')
                .WithMessage("El género del estudiante debe ser 'M' (Masculino), 'F' (Femenino), o 'O' (Otro)");

            RuleFor(x => x.StudentParentName)
                .Matches(@"^[^{}<>]*$").WithMessage("El nombre del padre/madre/tutor solo no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El nombre del padre/madre/tutor solo puede contener letras")
                .MaximumLength(50).WithMessage("El nombre del padre/madre/tutor del estudiante no puede exceder 50 caracteres");
        }
    }
}
