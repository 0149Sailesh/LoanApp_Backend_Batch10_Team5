using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Entities
{
    public class EmployeeCardDetailsEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Employee_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Loan_Id { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Card_Issue_Date { get; set; }
    }
}
