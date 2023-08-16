using LoanAPI.Entites;
using LOANAPI.Entites;
using LoanAPI.DTOs;
namespace LoanAPI.Service
{   
    public interface ILoanCardMasterService
    {
        void AddLoanCard(LoanCardMasterEntity loan_card);
        List<LoanCardMasterEntity> GetLoanCards();
        LoanCardMasterEntity GetLoanCard(string id);
        void EditLoanCard(LoanCardMasterEntity loan_card);
        void DeleteLoanCard(string id);


    }
}
