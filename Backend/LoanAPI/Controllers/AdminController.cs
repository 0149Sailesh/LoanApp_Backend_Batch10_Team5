using LoanAPI.Entites;
using LoanAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            Console.WriteLine("Enter into Admin Controller");
            this.adminService = adminService;
        }
        //Endpoints
        [HttpPost, Route("RegisterAdmin")]
        public IActionResult Add(AdminEntity admin)
        {
            try
            {
                Console.WriteLine("Enter into Admin Controller");
                adminService.AddAdmin(admin);
                return StatusCode(200,"Employee Added");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
