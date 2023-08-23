using LOANAPI.Entites;
using LoanAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Entites;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCardDetailsController : ControllerBase
    {
        private readonly IEmployeeCardDetailsService _ecd;
        public EmployeeCardDetailsController(IEmployeeCardDetailsService ecd)
        {
            this._ecd = ecd;
        }

        [HttpPost, Route("RegisterEmployeeCardDetails")]
        [Authorize(Roles = "user, admin")]
        public IActionResult Add(EmployeeCardDetailsEntity ecd)
        {
            try
            {

                _ecd.AddEmployeeCardDetails(ecd);
                return StatusCode(200, new JsonResult(ecd,"EmployeeCardDetails Added"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAllEmployeeCardDetailss")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetAll()
        {
            List<EmployeeCardDetailsEntity> ecds = _ecd.GetEmployeeCardDetails();
            try
            {
                return StatusCode(200, ecds);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetEmployeeCardDetails/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetEmployeeCardDetails(string id)
        {
            try
            {
                EmployeeCardDetailsEntity ecd = _ecd.GetEmployeeCardDetail(id);
                return StatusCode(200, ecd);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditEmployeeCardDetails")]
        [Authorize(Roles = "user, admin")]
        public IActionResult Update(EmployeeCardDetailsEntity ecd)
        {
            try
            {
                _ecd.EditEmployeeCardDetails(ecd);
                return StatusCode(200, new JsonResult("EmployeeCardDetails Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteEmployeeCardDetails/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _ecd.DeleteEmployeeCardDetails(id);
                return StatusCode(200, new JsonResult("EmployeeCardDetails Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
