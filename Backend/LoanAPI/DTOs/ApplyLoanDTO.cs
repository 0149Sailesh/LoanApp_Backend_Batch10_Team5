namespace LoanAPI.DTOs
{
    public class ApplyLoanDTO
    {
        public string Employee_Id { get; set; }
        public string Item_Category { get; set; }
        public string Item_Description { get; set; }
        public string Item_Value{ get; set; }
        public string Item_Make { get; set; }
        public DateTime Date_of_Application { get; set; }
        //public DateTime Date_of_Joining { get; set; }
    }
}
