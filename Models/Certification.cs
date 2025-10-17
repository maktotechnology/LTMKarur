using System.ComponentModel.DataAnnotations;

namespace LTMKarur.Models
{
    public class Certification
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Certification Name")]
        public string Name { get; set; } = string.Empty;
    }
}
