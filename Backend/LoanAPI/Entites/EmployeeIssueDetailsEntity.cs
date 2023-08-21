using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LOANAPI.Entites
{
    public class EmployeeIssueDetailsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable identity
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Issue_Id { get; set; }

        [Required] //applies not null constraint
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Employee_Id { get; set; }

        [Required] //applies not null constraint
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [ForeignKey("ItemMasterEntity")]
        public string Item_Id { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Issue_Date { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Return_Date { get; set; }
    }
}