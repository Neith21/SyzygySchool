using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
    public class TeacherValidator : AbstractValidator<TeacherModel>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.TeacherName)
                .Matches(@"^[^{}<>]*$").WithMessage("El nombre del profesor no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El nombre del profesor solo puede contener letras")
                .MaximumLength(50).WithMessage("El nombre del profesor no puede exceder 50 caracteres");

            RuleFor(x => x.TeacherLastName)
                .Matches(@"^[^{}<>]*$").WithMessage("El apellido del profesor no puede contener { o } o < o >")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$").WithMessage("El apellido del profesor solo puede contener letras")
                .MaximumLength(50).WithMessage("El apellido del profesor no puede exceder 50 caracteres");

            RuleFor(x => x.TeacherAge)
                .Must(age => age is int).WithMessage("La edad del profesor debe ser un número entero válido")
                .InclusiveBetween(20, 90).WithMessage("La edad del profesor debe estar entre 20 y 90");

            RuleFor(x => x.TeacherGender)
                .Must(g => g == 'M' || g == 'F' || g == 'O')
                .WithMessage("El género del profesor debe ser 'M' (Masculino), 'F' (Femenino), o 'O' (Otro)");

            RuleFor(x => x.TeacherPhone)
                .Matches(@"^[0-9]*$").WithMessage("El número de teléfono del profesor solo puede contener números")
                .MaximumLength(30).WithMessage("El número de teléfono del profesor no puede exceder 30 caracteres");

            RuleFor(x => x.TeacherEmail)
                .EmailAddress().WithMessage("El correo electrónico del profesor debe ser una dirección de correo válida")
                .MaximumLength(75).WithMessage("El correo electrónico del profesor no puede exceder 75 caracteres");
        }
    }
}
