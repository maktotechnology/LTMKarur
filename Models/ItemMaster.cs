using System.ComponentModel.DataAnnotations;

namespace LTMKarur.Models
{
    public class ItemMaster
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string WarpCount { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string WeftCount { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Ends/Inch (EPI)")]
        public decimal EPI { get; set; }

        [Required]
        [Display(Name = "Picks/Inch (PPI)")]
        public decimal PPI { get; set; }

        [Required]
        public decimal Width { get; set; }

        public string? Design { get; set; }
        public decimal? Crimp { get; set; }
        public decimal? Input { get; set; }

        [Display(Name = "Read on Loom")]
        public decimal? ReadOnLoom { get; set; }

        public decimal? Dent { get; set; }

        [Display(Name = "Warp Ends / Beam")]
        public decimal? WarpEndsPerBeam { get; set; }

        [Display(Name = "Warp Weight")]
        public decimal? WarpWeight { get; set; }

        [Display(Name = "Ends / Dent")]
        public decimal? EndsPerDent { get; set; }

        public decimal? GSM { get; set; }

        [Display(Name = "Stock Quantity")]
        public decimal? StockQuantity { get; set; }

        [Display(Name = "Warehouse Name")]
        [StringLength(100)]
        public string? WarehouseName { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName => $"{WarpCount}x{WeftCount}-{EPI}x{PPI}-{Width}";
    }
}
