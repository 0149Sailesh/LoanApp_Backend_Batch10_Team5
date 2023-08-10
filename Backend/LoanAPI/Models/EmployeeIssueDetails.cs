using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models
{
    public class EmployeeIssueDetails
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Issue_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMaster")]
        public string Employee_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("ItemMaster")]
        public string Item_Id { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Issue_Date { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Return_Date { get; set; }
    }
}
