﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models
{
    public class EmployeeCardDetails
    {
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Employee_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Loan_Id { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Card_Issue_Date { get; set; }
    }
}
