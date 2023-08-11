using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LOANAPI.Entites
{
    public class EmployeeMastersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
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
        [Column(TypeName = "DateTime")]
        public DateTime Date_of_Birth { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Date_of_Joining { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Password { get; set; }
    }
}