using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SectionModel
    {
        [Key]
        public int SectionId { get; set; }

        [Required]
        [StringLength(50)]
        public string SectionName { get; set; }
        
        [StringLength(50)]
        public string SectionInfo { get; set; }

    }
}
