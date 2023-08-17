using LOANAPI.Entites;
using LoanAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Entites;

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
        public IActionResult Add(EmployeeCardDetailsEntity ecd)
        {
            try
            {

                _ecd.AddEmployeeCardDetails(ecd);
                return StatusCode(200, new JsonResult("EmployeeCardDetails Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("GetAllEmployeeCardDetailss")]
        public IActionResult GetAll()
        {
            List<EmployeeCardDetailsEntity> ecds = _ecd.GetEmployeeCardDetails();
            try
            {
                return StatusCode(200, ecds);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetEmployeeCardDetails/{id}")]
        public IActionResult GetEmployeeCardDetails(string id)
        {
            try
            {
                EmployeeCardDetailsEntity ecd = _ecd.GetEmployeeCardDetail(id);
                return StatusCode(200, ecd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditEmployeeCardDetails")]
        public IActionResult Update(EmployeeCardDetailsEntity ecd)
        {
            try
            {
                _ecd.EditEmployeeCardDetails(ecd);
                return StatusCode(200, new JsonResult("EmployeeCardDetails Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteEmployeeCardDetails/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _ecd.DeleteEmployeeCardDetails(id);
                return StatusCode(200, new JsonResult("EmployeeCardDetails Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
