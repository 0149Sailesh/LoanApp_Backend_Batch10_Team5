using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanAPI.DTOS
{
    public class AdminDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
