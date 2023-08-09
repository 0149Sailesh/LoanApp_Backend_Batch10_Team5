﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models
{
    public class EmployeeIssueDetails
    {
        [Key]
        public string Issue_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [ForeignKey("EmployeeMasterEntity")]
        public string Employee_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [ForeignKey("ItemMasterEntity")]
        public string Item_Id { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Issue_Date { get; set; }

        [Required]
        [Column(TypeName = "DateOnly")]
        public DateOnly Return_Date { get; set; }
    }
}
