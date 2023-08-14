using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Service;
using LoanAPI.Entites;
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
        //Endpoints
        [HttpPost, Route("LoginEmployee")]
        public IActionResult Login([FromBody] EmployeeMastersEntity employee)
        {
            var user = Authenticate(employee);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(EmployeeMastersEntity employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Username),
            new Claim(ClaimTypes.Email, employee.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
              _config["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private EmployeeMastersEntity Authenticate(EmployeeMastersEntity employee)
        {
        //    //var currentUser = AdminConstants.Admins.FirstOrDefault(o => o.Username.ToLower() == admin.Username.ToLower() && o.Password == admin.Password);
            var currentUser = _dbconteact.EMEntity.FirstOrDefault(o => o.Username.ToLower() ==  employee.Username.ToLower() && o.Password == employee.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
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
