using System.ComponentModel.DataAnnotations;

namespace LTMKarur.Models;

public class CountMaster
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string CountName { get; set; } = string.Empty;  // e.g., 20s, 30s

    [StringLength(150)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? UOM { get; set; } // Unit of Measurement (Kg, Meter, Cone, etc.)
}
    