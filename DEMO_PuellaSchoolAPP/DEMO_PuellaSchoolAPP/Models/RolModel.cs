using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class RolModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "La nombre del rol es obligatoria")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "La informacion del rol es obligatoria")]
        public string RoleInfo { get; set; }
    }

    public enum rolType
    {
        Admin,
        Teacher
    }
}
