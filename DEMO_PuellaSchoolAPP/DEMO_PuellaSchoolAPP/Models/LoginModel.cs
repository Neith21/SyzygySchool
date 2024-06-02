using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }

        [Required(ErrorMessage = "La Username es obligatoria")]
        public string LoginUser { get; set; }

        [Required(ErrorMessage = "La Contraseña es obligatoria")]
        public string LoginPassword { get; set; }

        [Required(ErrorMessage = "El ID del Docente es obligatoria")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "el ID del rol es obligatoria")]
        public int RoleId { get; set; }

        public RolModel Roles { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
