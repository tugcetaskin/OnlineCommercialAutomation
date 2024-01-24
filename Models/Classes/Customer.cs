using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsiniz.")]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]
        public string CustomerLastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public virtual ICollection<SalesMove> SalesMoves {get; set;}
        public bool IsActive { get; set; }
    }
}