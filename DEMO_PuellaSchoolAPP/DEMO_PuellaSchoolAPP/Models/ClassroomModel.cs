using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassroomModel
    {
        [Key]
        public int ClassroomId { get; set; }

        public int ClassId { get; set; }

        public int StudentId { get; set; }

        public StudentModel? Students { get; set; }
        public ClassModel? Classes { get; set; }

    }
}
