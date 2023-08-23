using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanCardMasterController : ControllerBase
    {
        private readonly ILoanCardMasterService Loan_card;
        public LoanCardMasterController(ILoanCardMasterService loan_card)
        {
            this.Loan_card = loan_card;
        }

        [HttpPost, Route("RegisterLoanCard")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(LoanCardMasterEntity loan_card)
        {
            try
            {

                Loan_card.AddLoanCard(loan_card);
                return StatusCode(200, new JsonResult(loan_card,"LoanCard Added"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAllLoanCards")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetAll()
        {
            List<LoanCardMasterEntity> loan_cards = Loan_card.GetLoanCards();
            try
            {
                return StatusCode(200, loan_cards);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetLoanCard/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetLoanCard(string id)
        {
            try
            {
                LoanCardMasterEntity loan_card = Loan_card.GetLoanCard(id);
                return StatusCode(200, loan_card);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditLoanCard")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(LoanCardMasterEntity loan_card)
        {
            try
            {
                Loan_card.EditLoanCard(loan_card);
                return StatusCode(200, new JsonResult("LoanCard Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteLoanCard/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                Loan_card.DeleteLoanCard(id);
                return StatusCode(200, new JsonResult("LoanCard Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
