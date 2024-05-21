using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class AuxStudentClassModel
    {
        [Key]
        public int IdAux { get; set; }

        [Required]
        public int IdClass { get; set; }

        [Required]
        public int IdStudent { get; set; }

        [ForeignKey("IdClass")]
        public ClassModel Class { get; set; }

        [ForeignKey("IdStudent")]
        public StudentModel Student { get; set; }
    }
}
