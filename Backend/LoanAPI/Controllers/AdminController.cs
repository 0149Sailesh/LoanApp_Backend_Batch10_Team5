using LoanAPI.Entites;
using LoanAPI.Service;
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
        public IActionResult Login([FromBody] AdminEntity admin)
        {
            var user = Authenticate(admin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
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
                new Claim(ClaimTypes.Email, admin.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
              _config["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private AdminEntity Authenticate(AdminEntity admin)
        {
            //var currentUser = AdminConstants.Admins.FirstOrDefault(o => o.Username.ToLower() == admin.Username.ToLower() && o.Password == admin.Password);
            var currentUser = _dbconteact.AdminEntity.FirstOrDefault(o => o.Username.ToLower() == admin.Username.ToLower() && o.Password == admin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
        [HttpPost, Route("RegisterAdmin")]
        public IActionResult Add(AdminEntity admin)
        {
            try
            {

                adminService.AddAdmin(admin);
                return StatusCode(200, new JsonResult("Admin Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetAllAdmins")]
        [Authorize]
        public IActionResult GetAll()
        {
            List<AdminEntity> admins = adminService.GetAdmins();
            try
            {
                return StatusCode(200, admins);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetAdmin/{id}")]
        public IActionResult GetAdmin(string id)
        {
            try
            {
                AdminEntity admin = adminService.GetAdmin(id);
                return StatusCode(200, admin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditAdmin")]
        public IActionResult Update(AdminEntity admin)
        {
            try
            {
                adminService.EditAdmin(admin);
                return StatusCode(200, new JsonResult("Admin Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteAdmin/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                adminService.DeleteAdmin(id);
                return StatusCode(200, new JsonResult("Admin Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
