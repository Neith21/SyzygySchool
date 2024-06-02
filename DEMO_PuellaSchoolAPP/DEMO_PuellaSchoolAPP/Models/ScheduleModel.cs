using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ScheduleModel
    {
        public int IdSchedule { get; set; }

        public string ScheduleInfo { get; set; }

        [Required(ErrorMessage = "La fecha de creación del horario es obligatoria")]
        public DateTime ScheduleCreation { get; set; }

        [Required(ErrorMessage = "El día del horario es obligatorio")]
        public string ScheduleDay { get; set; }

        [Required(ErrorMessage = "La hora de inicio del horario es obligatoria")]
        public TimeSpan ScheduleStart { get; set; }

        [Required(ErrorMessage = "La hora de fin del horario es obligatoria")]
        public TimeSpan ScheduleEnd { get; set; }

        [Required(ErrorMessage = "La fecha de expiración del horario es obligatoria")]
        public DateTime ScheduleExpiration { get; set; }

        [Required(ErrorMessage = "La asignatura es obligatoria")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "El profesor es obligatorio")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "La clase es obligatoria")]
        public int ClassId { get; set; }

        public SubjectModel Subject { get; set; }

        public TeacherModel Teacher { get; set; }

        public ClassModel Class { get; set; }
    }
}
