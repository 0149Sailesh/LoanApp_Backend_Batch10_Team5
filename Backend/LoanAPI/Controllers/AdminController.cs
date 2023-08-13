using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        //Endpoints
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
