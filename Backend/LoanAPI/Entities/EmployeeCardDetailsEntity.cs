using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Entites
{
    public class EmployeeCardDetailsEntity
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Card_Id { get; set; }


        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Employee_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("LoanCardMaster")]
        public string Loan_Id { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Card_Issue_Date { get; set; }
    }
}
