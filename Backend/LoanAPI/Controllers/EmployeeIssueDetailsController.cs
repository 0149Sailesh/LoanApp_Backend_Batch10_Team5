using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeIssueDetailsController : ControllerBase
    {
        private readonly IEmployeeIssueDetailsService _esd;
        public EmployeeIssueDetailsController(IEmployeeIssueDetailsService esd)
        {
            this._esd = esd;
        }

        [HttpPost, Route("RegisterEmployeeIssueDetails")]
        public IActionResult Add(EmployeeIssueDetailsEntity esd)
        {
            try
            {

                _esd.AddEmployeeIssueDetails(esd);
                return StatusCode(200, new JsonResult("EmployeeIssueDetails Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("GetAllEmployeeIssueDetailss")]
        public IActionResult GetAll()
        {
            List<EmployeeIssueDetailsEntity> esds = _esd.GetEmployeeIssueDetails();
            try
            {
                return StatusCode(200, esds);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetEmployeeIssueDetails/{id}")]
        public IActionResult GetEmployeeIssueDetails(string id)
        {
            try
            {
                EmployeeIssueDetailsEntity esd = _esd.GetEmployeeIssueDetail(id);
                return StatusCode(200, esd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditEmployeeIssueDetails")]
        public IActionResult Update(EmployeeIssueDetailsEntity esd)
        {
            try
            {
                _esd.EditEmployeeIssueDetails(esd);
                return StatusCode(200, new JsonResult("EmployeeIssueDetails Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteEmployeeIssueDetails/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _esd.DeleteEmployeeIssueDetails(id);
                return StatusCode(200, new JsonResult("EmployeeIssueDetails Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
