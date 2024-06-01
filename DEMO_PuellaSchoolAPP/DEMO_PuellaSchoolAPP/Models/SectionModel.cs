using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SectionModel
    {
        public int SectionId { get; set; }

        [Required(ErrorMessage = "El nombre de la sección es obligatorio")]
        public string SectionName { get; set; }

        public string SectionInfo { get; set; }

    }
}
