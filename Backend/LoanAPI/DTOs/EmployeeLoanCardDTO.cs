namespace LoanAPI.DTOs
{
    public class EmployeeLoanCardDTO
    {
        public string Loan_Id { get; set; }
        public string Loan_Type { get; set; }
        public int Duration { get; set; }
        public DateTime Card_Issue_Date { get; set; }
    }
}
