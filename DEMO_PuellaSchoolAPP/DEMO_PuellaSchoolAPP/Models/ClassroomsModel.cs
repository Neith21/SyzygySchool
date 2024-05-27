using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassroomsModel
    {
        [Key]
        public int ClassroomId { get; set; }

        public int ClassId { get; set; }

        public int StudentId { get; set; }

        public StudentsModel? Students { get; set; }
        public ClassesModel? Classes { get; set; }

    }
}
