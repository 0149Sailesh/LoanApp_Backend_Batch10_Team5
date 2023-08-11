using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Service;
using LoanAPI.Entites;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMaster : ControllerBase
    {
        //private readonly IEmployeeMasterService _employeemasterservice;
        //public EmployeeMaster()
        //{
        //    _employeemasterservice = new EmployeeMasterService();
        //}
        //[HttpGet, Route("GetAllEmployees")]
        //public IActionResult GetAll()
        //{
        //    try
        //    {

        //        return StatusCode(200, _employeemasterservice.GetAll()); //Employee list is sending as josn form
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpGet, Route("GetEmployeeById/{id}")]
        //public IActionResult GetEmployee(int id)
        //{
        //    try
        //    {
        //        EmployeeMaster    employee = _employeemasterservice.Get(id);
        //        if (employee != null)
        //        {
        //            return StatusCode(200, employee);
        //        }
        //        else
        //        {
        //            return StatusCode(404, "Invalid Id");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpPost, Route("AddEmployee")]
        //public IActionResult AddEmployee(EmployeeMasterDTO employeeDTO)
        //{
        //    try
        //    {
        //        _employeemasterservice.Add(employeeDTO);
        //        return StatusCode(200, "Employee Added");
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpPut, Route("EditEmployee")]
        //public IActionResult EditEmployee(EmployeeMasterDTO employeeDTO)
        //{
        //    try
        //    {
        //        _employeemasterservice.Update(employeeDTO);
        //        return StatusCode(200, "Employee Edited");
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpDelete, Route("DeleteEmployee/{id}")]
        //public IActionResult DeleteEmployee(int id)
        //{
        //    try
        //    {
        //        _employeemasterservice.Delete(id);
        //        return StatusCode(200, "Employee Deleted");
        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
