using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Service;
using LoanAPI.Entites;
using LOANAPI.Entites;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeMasterController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        //Endpoints
        [HttpPost, Route("RegisterEmployee")]
        public IActionResult Add(EmployeeMastersEntity employee)
        {
            try
            {

                employeeService.AddEmployee(employee);
                return StatusCode(200, new JsonResult("Employee Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetAllEmployees")]
        public IActionResult GetAll()
        {
            List<EmployeeMastersEntity> employees = employeeService.GetEmployees();
            try
            {
                return StatusCode(200, employees);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetEmployee/{id}")]
        public IActionResult GetEmployee(string id)
        {
            try
            {
                EmployeeMastersEntity employee = employeeService.GetEmployee(id);
                return StatusCode(200, employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditEmployee")]
        public IActionResult Update(EmployeeMastersEntity employee)
        {
            try
            {
                employeeService.EditEmployee(employee);
                return StatusCode(200, new JsonResult("Employee Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteEmployee/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                employeeService.DeleteEmployee(id);
                return StatusCode(200, new JsonResult("Employee Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
