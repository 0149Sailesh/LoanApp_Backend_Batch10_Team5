using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "user, admin")]
        public IActionResult Add(EmployeeIssueDetailsEntity esd)
        {
            try
            {

                _esd.AddEmployeeIssueDetails(esd);
                return StatusCode(200, new JsonResult(esd,"EmployeeIssueDetails Added"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAllEmployeeIssueDetailss")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetAll()
        {
            List<EmployeeIssueDetailsEntity> esds = _esd.GetEmployeeIssueDetails();
            try
            {
                return StatusCode(200, esds);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetEmployeeIssueDetails/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetEmployeeIssueDetails(string id)
        {
            try
            {
                EmployeeIssueDetailsEntity esd = _esd.GetEmployeeIssueDetail(id);
                return StatusCode(200, esd);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditEmployeeIssueDetails")]
        [Authorize(Roles = "user, admin")]
        public IActionResult Update(EmployeeIssueDetailsEntity esd)
        {
            try
            {
                _esd.EditEmployeeIssueDetails(esd);
                return StatusCode(200, new JsonResult("EmployeeIssueDetails Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteEmployeeIssueDetails/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _esd.DeleteEmployeeIssueDetails(id);
                return StatusCode(200, new JsonResult("EmployeeIssueDetails Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
