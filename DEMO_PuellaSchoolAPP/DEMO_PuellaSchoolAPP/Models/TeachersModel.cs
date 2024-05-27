using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class TeachersModel
    {
        [Key]
        public int TeacherID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherLastName { get; set; }

        [Required]
        public int TeacherAge { get; set; }

        [StringLength(1)]
        public int TeacherGender { get; set; }

        [StringLength(9)]
        public string TeacherPhone { get; set; }

        [StringLength(50)]
        public string TeacherEmail { get; set; }

        [StringLength(75)]
        public string TeacherToken { get; set; }
    }
}
