using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class StudentsModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentLastName { get; set; }

        [Required]
        public int StudentAge { get; set; }

        [StringLength(1)]
        public string StudentGender { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentParentName { get; set; }
    }
}
