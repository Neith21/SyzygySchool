using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class LoginModel
    {
        [Key]
        public int IdLogin { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUser { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginPassword { get; set; }

        [Required]
        public int IdTeacher { get; set; }

        [Required]
        public int IdRol { get; set; }

        [ForeignKey("IdTeacher")]
        public TeacherModel Teacher { get; set; }

        [ForeignKey("IdRol")]
        public RolModel Rol { get; set; }
    }
}
