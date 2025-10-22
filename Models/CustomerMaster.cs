using System.ComponentModel.DataAnnotations;

namespace LTMKarur.Models
{
    public class CustomerMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;
    }
}
