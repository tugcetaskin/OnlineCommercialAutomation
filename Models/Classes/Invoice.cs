using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSequenceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration {  get; set; }
        
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Total { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}