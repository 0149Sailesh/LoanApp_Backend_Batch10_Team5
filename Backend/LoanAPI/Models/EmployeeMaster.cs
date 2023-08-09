using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Models
{
    public class EmployeeMaster
    {
        [Key]
        public string[] Employee_Id { get; set; }

        [Required]
        public string[] Employee_Name { get; set;}

        [Required]
        public Char Employee_Gender { get; set;}

        [Required]
        public string[] Designation { get; set; }

        [Required]
        public string[] Department { get; set; }

        [Required]
        public DateOnly Date_of_Birth { get; set; }

        [Required]
        public DateOnly Date_of_Joining { get; set; }
    }
}
