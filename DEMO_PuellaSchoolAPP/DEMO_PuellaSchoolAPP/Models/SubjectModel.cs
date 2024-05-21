using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SubjectModel
    {
        [Key]
        public int IdSubject { get; set; }

        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }

        [StringLength(50)]
        public string SubjectLevel { get; set; }

        [StringLength(50)]
        public string SubjectInfo { get; set; }
    }
}
