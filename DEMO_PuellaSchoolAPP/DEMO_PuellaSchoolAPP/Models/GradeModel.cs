using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class GradeModel
    {
        [Key]
        public int GradeId { get; set; }

        public string GradeName { get; set;}
    }
}
