using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanAPI.DTOs
{
    public class EmployeeMasterDTO
    {
        public string Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1)]
        public string Employee_Gender { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public DateTime Date_of_Joining { get; set; }

    }
}
