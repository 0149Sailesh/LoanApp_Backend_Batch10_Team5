using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Service;
using LoanAPI.Entites;
 using LoanAPI.DTOs;
using LOANAPI.Entites;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private IConfiguration _config;
        private readonly LoanDbContext _dbconteact;

        public EmployeeMasterController(IEmployeeService employeeService, IConfiguration config, LoanDbContext dbconteact)
        {
            this.employeeService = employeeService;
            _config = config;
            _dbconteact = dbconteact;
        }
        //Endpoints
        [HttpPost, Route("RegisterEmployee")]
        public IActionResult Add(EmployeeMasterDTO employeeDTO)
        {
            try
            {

                employeeService.AddEmployee(employeeDTO);
                return StatusCode(200, new JsonResult("Employee Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Endpoints
        [HttpPost, Route("LoginEmployee")]
        public IActionResult Login([FromBody] EmployeeMasterLoginDTO employee_loginDTO)
        {
            var user = Authenticate(employee_loginDTO);

            if (user != null)
            {
                
                var token = Generate(user);
                var user_response = new EmployeeMasterDTO()
                {
                    Employee_Id = user.Employee_Id,
                    Employee_Name = user.Employee_Name,
                    Employee_Gender = user.Employee_Gender,
                    Designation = user.Designation,
                    Department = user.Department,
                    Date_of_Birth = user.Date_of_Birth,
                    Date_of_Joining = user.Date_of_Joining
                };
                return Ok(new { tokenDet = token, userDet = user_response, user_role = "user" });
            }

            return NotFound("User not found");
        }

        private string Generate(EmployeeMastersEntity employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Employee_Id)
            };

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
              _config["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private EmployeeMastersEntity Authenticate(EmployeeMasterLoginDTO employee_loginDTO)
        {
        //    //var currentUser = AdminConstants.Admins.FirstOrDefault(o => o.Employee_Id.ToLower() == admin.Employee_Id.ToLower() && o.Password == admin.Password);
            var currentUser = _dbconteact.EMEntity.FirstOrDefault(o => o.Employee_Id.ToLower() == employee_loginDTO.Username.ToLower() && o.Password == employee_loginDTO.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

            [HttpGet, Route("GetAllEmployees")]
        public IActionResult GetAll()
        {
            List<EmployeeMasterDTO> employees = employeeService.GetEmployees();
            try
            {
                return StatusCode(200, employees);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet, Route("GetAllEmployeesLoanCard/{id}")]
        public IActionResult GetAllEmployeesLoanCard(string id)
        {
            List<EmployeeLoanCardDTO> employees_loan_card = employeeService.GetEmployeesLoanCard(id);
            try
            {
                return StatusCode(200, employees_loan_card);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("GetAllEmployeesItemPurchase/{id}")]
        public IActionResult GetAllEmployeesItemPurchase(string id)
        {
            List<EmployeeItemPurchaseDTO> employees_item_purchase = employeeService.GetEmployeesItemPurchase(id);
            try
            {
                return StatusCode(200, employees_item_purchase);
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
                EmployeeMasterDTO employee = employeeService.GetEmployee(id);
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
