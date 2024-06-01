using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassModel
    {
        [Key]
        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public int SectionId { get; set; }

        public SectionModel? Sections { get; set; }
        public GradeModel? Grades { get; set; }
    }
}
