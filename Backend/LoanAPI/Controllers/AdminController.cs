using LoanAPI.Entites;
using LoanAPI.Service;
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
                return StatusCode(200, admin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
