using System.ComponentModel.DataAnnotations;

namespace DEMO_PuellaSchoolAPP.Models
{
    public class SectionModel
    {
        [Display(Name = "ID de Sección")]
        public int SectionId { get; set; }

        [Display(Name = "Nombre de Sección")]
        [Required(ErrorMessage = "El nombre de la sección es obligatorio")]
        public string SectionName { get; set; }

        [Display(Name = "Información de Sección")]
        public string SectionInfo { get; set; }
    }
}
