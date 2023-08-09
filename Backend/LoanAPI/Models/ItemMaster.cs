using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Models
{
    public class ItemMaster
    {
        [Key]
        public string[] Item_Id { get; set; }

        [Required]
        public string[] Item_Description { get; set; }

        [Required]
        public Char Issue_Status { get; set; }

        [Required]
        public string[] Item_Make { get; set; }

        [Required]
        public string[] Item_Category { get; set; }

        [Required]
        public int Item_Valuation { get; set; }

    }
}
