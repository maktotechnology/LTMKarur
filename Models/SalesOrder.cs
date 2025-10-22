using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTMKarur.Models
{
    public class SalesOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Series ID")]
        public string SeriesID { get; set; } = string.Empty;

        public string? CustomerPO { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerMaster? Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        public ICollection<SalesOrderItem>? Items { get; set; }

        // ✅ New relationship: Certifications selected for this order
        public ICollection<SalesOrderCertification>? SalesOrderCertifications { get; set; }
    }

    public class SalesOrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SalesOrderId { get; set; }

        [ForeignKey("SalesOrderId")]
        public SalesOrder? SalesOrder { get; set; }

        [Required]
        public string ItemName { get; set; } = string.Empty;

        public string? UOM { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ItemDeliveryDate { get; set; }

        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }

        [NotMapped]
        public decimal Amount => Quantity * Rate;
    }

    // ✅ Linking Table
    public class SalesOrderCertification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SalesOrderId { get; set; }

        [Required]
        public int CertificationId { get; set; }

        [ForeignKey("SalesOrderId")]
        public SalesOrder? SalesOrder { get; set; }

        [ForeignKey("CertificationId")]
        public Certification? Certification { get; set; }
    }
}
