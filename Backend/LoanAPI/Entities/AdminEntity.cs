using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Entities
{
    public class AdminEntity
    {
        [Key]
        [Required(ErrorMessage = "User Name is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string? Password { get; set; }
    }
}
