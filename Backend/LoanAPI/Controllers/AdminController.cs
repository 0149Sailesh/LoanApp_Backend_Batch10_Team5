﻿using LoanAPI.Entites;
using LoanAPI.Service;
using LoanAPI.DTOs;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private IConfiguration _config;
        private readonly LoanDbContext _dbconteact;
        public AdminController(IAdminService adminService, IConfiguration config, LoanDbContext dbconteact)
        {
            this.adminService = adminService;
            _config = config;
            _dbconteact = dbconteact;
        }
        //Endpoints
        [HttpPost, Route("LoginAdmin")]
        public IActionResult Login([FromBody] AdminLoginDTO admin_loginDTO)
        {
            var user = Authenticate(admin_loginDTO);

            if (user != null)
            {
                var token = Generate(user);
                var admin = new AdminResponseDTO()
                {
                    Username = user.Username,
                    Email = user.Email,
                };
                return Ok(new { tokenDet = token, userDet = admin, user_role = "admin" });
            }

            return NotFound("User not found");
        }

        private string Generate(AdminEntity admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Username),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Email, admin.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
              _config["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddHours(48),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private AdminEntity Authenticate(AdminLoginDTO admin_loginDTO)
        {
            //var currentUser = AdminConstants.Admins.FirstOrDefault(o => o.Username.ToLower() == admin.Username.ToLower() && o.Password == admin.Password);
            var currentUser = _dbconteact.AdminEntity.FirstOrDefault(o => o.Username.ToLower() == admin_loginDTO.Username.ToLower() && o.Password == admin_loginDTO.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
        [HttpPost, Route("RegisterAdmin")]
        //[Authorize(Roles = "admin")]
        public IActionResult Add(AdminEntity admin)
        {
            try
            {

                adminService.AddAdmin(admin);
                return StatusCode(200, new JsonResult(admin,"Admin Added"));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetAllAdmins")]
        //[Authorize]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            List<AdminEntity> admins = adminService.GetAdmins();
            try
            {

                return StatusCode(200, admins);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAdmin")]
        [Authorize]
        public IActionResult GetAdmin()
        {
            return StatusCode(200);
           
        }
        [HttpPut, Route("EditAdmin")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(AdminEntity admin)
        {
            try
            {
                adminService.EditAdmin(admin);
                return StatusCode(200, new JsonResult("Admin Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteAdmin/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                adminService.DeleteAdmin(id);
                return StatusCode(200, new JsonResult("Admin Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
