using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(LoanCardMasterEntity loan_card)
        {
            try
            {

                Loan_card.AddLoanCard(loan_card);
                return StatusCode(200, new JsonResult("LoanCard Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("GetAllLoanCards")]
        public IActionResult GetAll()
        {
            List<LoanCardMasterEntity> loan_cards = Loan_card.GetLoanCards();
            try
            {
                return StatusCode(200, loan_cards);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetLoanCard/{id}")]
        public IActionResult GetLoanCard(string id)
        {
            try
            {
                LoanCardMasterEntity loan_card = Loan_card.GetLoanCard(id);
                return StatusCode(200, loan_card);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditLoanCard")]
        public IActionResult Update(LoanCardMasterEntity loan_card)
        {
            try
            {
                Loan_card.EditLoanCard(loan_card);
                return StatusCode(200, new JsonResult("LoanCard Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteLoanCard/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Loan_card.DeleteLoanCard(id);
                return StatusCode(200, new JsonResult("LoanCard Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
