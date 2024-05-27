using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassesModel
    {
        [Key]
        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public int SectionId { get; set; }

        public SectionsModel? Sections { get; set; }
        public GradesModel? Grades { get; set; }
    }
}
