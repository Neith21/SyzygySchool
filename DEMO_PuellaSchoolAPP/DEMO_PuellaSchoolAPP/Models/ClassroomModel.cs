using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class ClassroomModel
    {
        [Key]
        public int IdClassroom { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassroomName { get; set; }

        [StringLength(50)]
        public string ClassroomInfo { get; set; }

        [StringLength(50)]
        public string ClassroomLocation { get; set; }
    }
}
