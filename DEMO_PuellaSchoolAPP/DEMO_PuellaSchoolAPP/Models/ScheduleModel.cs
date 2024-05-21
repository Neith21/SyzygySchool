using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ScheduleModel
    {
        [Key]
        public int IdSchedule { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public TimeSpan ScheduleStart { get; set; }

        [Required]
        public TimeSpan ScheduleEnd { get; set; }

        [Required]
        public int IdSubject { get; set; }

        [Required]
        public int IdTeacher { get; set; }

        [Required]
        public int IdClassroom { get; set; }

        [Required]
        public int IdClass { get; set; }

        [ForeignKey("IdSubject")]
        public SubjectModel Subject { get; set; }

        [ForeignKey("IdTeacher")]
        public TeacherModel Teacher { get; set; }

        [ForeignKey("IdClassroom")]
        public ClassroomModel Classroom { get; set; }

        [ForeignKey("IdClass")]
        public ClassModel Class { get; set; }
    }
}
