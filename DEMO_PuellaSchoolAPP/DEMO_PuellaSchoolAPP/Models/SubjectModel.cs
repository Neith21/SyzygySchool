using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "El nombre de la asignatura es obligatorio")]
        public string SubjectName { get; set; }

        public string SubjectInfo { get; set; }

        public int? GradeId { get; set; }

        public GradeModel? Grades { get; set; }
    }
}
