using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models
{
    public class ItemMaster
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Item_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Item_Description { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(1)]
        public string Issue_Status { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Item_Make { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Item_Category { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [MaxLength(6)]
        public int Item_Valuation { get; set; }

    }
}
