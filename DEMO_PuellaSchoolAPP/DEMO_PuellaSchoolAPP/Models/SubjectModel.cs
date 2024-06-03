using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "El nombre de la asignatura es obligatorio")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "El campo no puede quedar vacio")]
        public string SubjectInfo { get; set; }

        [Required(ErrorMessage = "El campo no puede quedar vacio")]
        public int? GradeId { get; set; }

        public GradeModel? Grades { get; set; }
    }
}
