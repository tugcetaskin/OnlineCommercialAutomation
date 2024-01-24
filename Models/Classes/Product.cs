using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public int Stock { get; set;}
        public decimal PurchasePrice { get; set;}
        public decimal SalePrice { get; set;}
        public bool Condition { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string? ProductImage { get; set;}
        public int CategoryId {get; set;}
        public virtual Category? Category { get; set;} 

        public ICollection<SalesMove>? SalesMoves {get; set;}
    }
}