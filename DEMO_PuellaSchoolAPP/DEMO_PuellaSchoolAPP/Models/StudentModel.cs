using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "El apellido del estudiante es obligatorio")]
        public string StudentLastName { get; set; }

        [Required(ErrorMessage = "La edad del estudiante es obligatoria")]
        public int? StudentAge { get; set; }

        [Required(ErrorMessage = "El género del estudiante es obligatorio")]
        public char? StudentGender { get; set; }

        [Required(ErrorMessage = "El nombre del padre/madre/tutor del estudiante es obligatorio")]
        public string StudentParentName { get; set; }
    }
}
