using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class GradeModel
    {
        [Key]
        public int IdGrade { get; set; }

        [Required]
        [StringLength(50)]
        public string GradeName { get; set; }
    }
}
