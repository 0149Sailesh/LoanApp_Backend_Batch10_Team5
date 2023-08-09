using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LOANAPI.Entites
{
    public class EmployeeMastersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Employee_Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Employee_Name { get; set; }

        [Required]
        [Column(TypeName = "char")]
        public char Employee_Gender { get; set; }

        [Required]
        [StringLength(25)]
        [Column(TypeName = "varchar")]
        public string Designation { get; set; }

        [Required]
        [StringLength(25)]
        [Column(TypeName = "varchar")]
        public string Department { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Date_of_Birth { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Date_of_Joining { get; set; }
    }
}