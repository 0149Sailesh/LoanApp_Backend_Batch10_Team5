using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyLoanController : ControllerBase
    {
        private readonly LoanDbContext _dbconteact;
        public ApplyLoanController(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }
        //Endpoints
        [HttpPost, Route("")]
        public IActionResult Add(ApplyLoanDTO loanDTO)
        {
            try
            {
                var loan_details = _dbconteact.LCMEntity.FirstOrDefault(o => o.Loan_Type.ToLower() == loanDTO.Item_Category.ToLower());
                var item_details = _dbconteact.IMEntity.FirstOrDefault(o => (o.Item_Category.ToLower() == loanDTO.Item_Category.ToLower() && o.Item_Make.ToLower() == loanDTO.Item_Make.ToLower() && o.Item_Valuation == loanDTO.Item_Value));

                if (loan_details != null && item_details != null && item_details.Issue_Status == "Y")
                {
                    EmployeeCardDetailsEntity emp = new EmployeeCardDetailsEntity()
                    {
                        Card_Id = Guid.NewGuid().ToString(),
                        Employee_Id = loanDTO.Employee_Id,
                        Loan_Id=loan_details.Loan_Id,
                        Card_Issue_Date=DateTime.Now
                    };
                                        
                    DateTime today = DateTime.Now;
                    DateTime return_date = today.AddDays(365 * loan_details.Duration);
                    EmployeeIssueDetailsEntity emp1 = new EmployeeIssueDetailsEntity()
                    {
                        Issue_Id = Guid.NewGuid().ToString(),
                        Employee_Id = loanDTO.Employee_Id,
                        Item_Id = item_details.Item_Id,
                        Issue_Date = DateTime.Now,
                        Return_Date = return_date
                    };
                    _dbconteact.ECDEntity.Add(emp);
                    _dbconteact.EIDEntity.Add(emp1);
                    _dbconteact.SaveChanges();
                    return StatusCode(200, new JsonResult("Employee Card and Issue Details added!"));
                    
                }
                
                return StatusCode(400, new JsonResult("Loan cannot be issued!"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
