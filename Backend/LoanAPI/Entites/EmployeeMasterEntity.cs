using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LOANAPI.Entites
{
    public class EmployeeMastersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Employee_Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Employee_Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(1)]
        //[Column(TypeName = "char")]

        public string Employee_Gender { get; set; }

        [Required]
        [StringLength(25)]
        [Column(TypeName = "varchar")]
        public string Designation { get; set; }

        [Required]
        [StringLength(25)]
        [Column(TypeName = "varchar")]
        public string Department { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Date_of_Birth { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Date_of_Joining { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}