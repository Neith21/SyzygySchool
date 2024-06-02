using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassroomModel
    {
        public int ClassroomId { get; set; }

        [Required(ErrorMessage = "La clase es obligatoria")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "El estudiante es obligatorio")]
        public int StudentId { get; set; }

        public StudentModel? Students { get; set; }

        public ClassModel? Class { get; set; }

    }
}
