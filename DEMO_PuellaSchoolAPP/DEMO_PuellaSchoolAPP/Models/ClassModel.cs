using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }

        [Required(ErrorMessage = "La información de la clase es obligatoria")]
        public string ClassInfo { get; set; }

        [Required(ErrorMessage = "El grado es obligatorio")]
        public int GradeId { get; set; }

        [Required(ErrorMessage = "La sección es obligatoria")]
        public int SectionId { get; set; }

        public GradeModel? Grades { get; set; }

        public SectionModel? Sections { get; set; }
    }

}
