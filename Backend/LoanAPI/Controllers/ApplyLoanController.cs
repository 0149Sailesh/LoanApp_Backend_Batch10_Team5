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
        [HttpPost, Route("ApplyforLoan")]
        public IActionResult Add(ApplyLoanDTO loanDTO)
        {
            try
            {
                var loan_details = _dbconteact.LCMEntity.FirstOrDefault(o => o.Loan_Type.ToLower() == loanDTO.Item_Category.ToLower());
                Random rnd = new Random();
                if (loan_details != null)
                {
                    EmployeeCardDetailsEntity emp = new EmployeeCardDetailsEntity()
                    {
                        Card_Id = "Ca"+rnd.Next(1,9)+rnd.Next(1,9)+rnd.Next(1,9),
                        Employee_Id = loanDTO.Employee_Id,
                        Loan_Id=loan_details.Loan_Id,
                        Card_Issue_Date=DateTime.Now
                    };
                    //_dbconteact.SaveChanges();
                    var item_details = _dbconteact.IMEntity.FirstOrDefault(o => o.Item_Category.ToLower() == loanDTO.Item_Category.ToLower());
                    if (item_details != null)
                    {
                        DateTime today = DateTime.Now;
                        DateTime return_date = today.AddDays(365 * loan_details.Duration);
                        EmployeeIssueDetailsEntity emp1 = new EmployeeIssueDetailsEntity()
                        {
                            Issue_Id = "Is" + rnd.Next(1, 9) + rnd.Next(1, 9) + rnd.Next(1,9),
                            Employee_Id = loanDTO.Employee_Id,
                            Item_Id = item_details.Item_Id,
                            Issue_Date = DateTime.Now,
                            Return_Date = DateTime.Now
                        };
                        _dbconteact.ECDEntity.Add(emp);
                        _dbconteact.EIDEntity.Add(emp1);
                        _dbconteact.SaveChanges();
                        return StatusCode(200, new JsonResult("Employee Card and Issue Details added!"));
                    }
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
