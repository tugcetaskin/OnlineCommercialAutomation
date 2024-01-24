using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public bool isActive {get; set;}
        public int EmployeeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}