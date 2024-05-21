using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class RolModel
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [StringLength(50)]
        public string RolName { get; set; }

        [StringLength(75)]
        public string RolInfo { get; set; }
    }
}
