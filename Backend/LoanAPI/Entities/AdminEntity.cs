using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Entites
{
    public class AdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Password { get; set; }
    }
}
