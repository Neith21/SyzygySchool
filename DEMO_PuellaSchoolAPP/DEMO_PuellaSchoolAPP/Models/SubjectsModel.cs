using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SubjectsModel
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }

        [StringLength(50)]
        public string SubjectInfo { get; set; }
        
        public int GradeId { get; set; }

        public GradesModel? Grades { get; set; }

    }
}
