using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class GradesModel
    {
        [Key]
        public int GradeId { get; set; }

        public string GradeName { get; set;}
    }
}
