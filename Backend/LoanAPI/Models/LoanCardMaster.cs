using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Models
{
    public class LoanCardMaster
    {
        [Key]
        public string[] Loan_Id { get; set; }

        [Required]
        public string[] Loan_Type { get; set; }

        [Required]
        public int Duration { get; set; }
        
        

    }
}
