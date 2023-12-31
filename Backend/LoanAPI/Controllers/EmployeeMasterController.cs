﻿using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "admin")]
        public IActionResult Add(EmployeeMasterDTO employeeDTO)
        {
            try
            {

                employeeService.AddEmployee(employeeDTO);
                return StatusCode(200, new JsonResult("Employee Added"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
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
                new Claim(ClaimTypes.NameIdentifier, employee.Employee_Id),
                new Claim(ClaimTypes.Role, "user")
            };

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
              _config["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddHours(48),
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
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            List<EmployeeMasterDTO> employees = employeeService.GetEmployees();
            try
            {
                return StatusCode(200, employees);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }


        [HttpGet, Route("GetAllEmployeesLoanCard/{id}")]
        [Authorize(Roles = "user")]
        public IActionResult GetAllEmployeesLoanCard(string id)
        {
            List<EmployeeLoanCardDTO> employees_loan_card = employeeService.GetEmployeesLoanCard(id);
            try
            {
                return StatusCode(200, employees_loan_card);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }

        [HttpGet, Route("GetAllEmployeesItemPurchase/{id}")]
        [Authorize(Roles ="user")]
        public IActionResult GetAllEmployeesItemPurchase(string id)
        {
            List<EmployeeItemPurchaseDTO> employees_item_purchase = employeeService.GetEmployeesItemPurchase(id);
            try
            {
                return StatusCode(200, employees_item_purchase);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }

        [HttpGet, Route("GetEmployee/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetEmployee(string id)
        {
            try
            {
                EmployeeMasterDTO employee = employeeService.GetEmployee(id);
                return StatusCode(200, employee);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }
        [HttpPut, Route("EditEmployee")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(EmployeeMastersEntity employee)
        {
            try
            {
                employeeService.EditEmployee(employee);
                return StatusCode(200, new JsonResult("Employee Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }
        [HttpDelete, Route("DeleteEmployee/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                employeeService.DeleteEmployee(id);
                return StatusCode(200, new JsonResult("Employee Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);;
            }
        }

    }
}
