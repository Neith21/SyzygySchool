using DEMO_PuellaSchoolAPP.Models;
using FluentValidation;

namespace DEMO_PuellaSchoolAPP.Validations
{
	public class ScheduleValidator : AbstractValidator<ScheduleModel>
	{
		public ScheduleValidator()
		{
			RuleFor(x => x.ScheduleInfo)
				.NotEmpty().WithMessage("La información del horario es obligatoria")
				.Matches(@"^[^{}<>]*$").WithMessage("El nombre del estudiante no puede contener { o } o < o >")
				.MaximumLength(100).WithMessage("La información del horario no puede exceder los 100 caracteres");

			RuleFor(x => x.ScheduleStart)
				.NotEmpty().WithMessage("La hora de inicio del horario es obligatoria");

			RuleFor(x => x.ScheduleEnd)
				.NotEmpty().WithMessage("La hora de fin del horario es obligatoria");

			RuleFor(x => x.ScheduleExpiration)
				.NotEmpty().WithMessage("La fecha de expiración del horario es obligatoria")
				.GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("La fecha de expiración del horario debe ser igual o posterior a la fecha actual");

			RuleFor(x => x.SubjectId)
				.NotEmpty().WithMessage("La asignatura es obligatoria");

			RuleFor(x => x.TeacherId)
				.NotEmpty().WithMessage("El profesor es obligatorio");

			RuleFor(x => x.ClassId)
				.NotEmpty().WithMessage("La clase es obligatoria");
		}
	}
}
