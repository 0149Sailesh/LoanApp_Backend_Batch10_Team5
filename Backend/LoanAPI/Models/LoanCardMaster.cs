using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models
{
    public class LoanCardMaster
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Loan_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Loan_Type { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [MaxLength(2)]
        public int Duration { get; set; }
        
        

    }
}
