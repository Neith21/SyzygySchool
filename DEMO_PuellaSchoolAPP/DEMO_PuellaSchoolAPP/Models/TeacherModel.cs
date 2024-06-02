using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "El nombre del profesor es obligatorio")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "El apellido del profesor es obligatorio")]
        public string TeacherLastName { get; set; }

        [Required(ErrorMessage = "La edad del profesor es obligatoria")]
        public int TeacherAge { get; set; }

        public char? TeacherGender { get; set; }

        public string TeacherPhone { get; set; }

        [Required(ErrorMessage = "El correo electrónico del profesor es obligatorio")]
        public string TeacherEmail { get; set; }

    }
}
