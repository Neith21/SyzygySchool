using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassModel
    {
        [Key]
        public int IdClass { get; set; }

        [Required]
        public int IdGrade { get; set; }

        [Required]
        public int IdSection { get; set; }

        [ForeignKey("IdGrade")]
        public GradeModel Grade { get; set; }

        [ForeignKey("IdSection")]
        public SectionModel Section { get; set; }
    }
}
