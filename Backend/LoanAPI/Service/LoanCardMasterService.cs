using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Models;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public class LoanCardMasterService : ILoanCardMasterService
    {
        private readonly LoanDbContext _dbconteact;

        public LoanCardMasterService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddLoanCard(LoanCardMasterEntity loan_card)
        {
            
            _dbconteact.LCMEntity.Add(loan_card);
            _dbconteact.SaveChanges();
        }
        public void DeleteLoanCard(string id)
        {
            LoanCardMasterEntity loan_card = _dbconteact.LCMEntity.Find(id);
            _dbconteact.LCMEntity.Remove(loan_card);
            _dbconteact.SaveChanges();

        }
        public void EditLoanCard(LoanCardMasterEntity loan_card)
        {
            _dbconteact.LCMEntity.Update(loan_card);
            _dbconteact.SaveChanges();
        }
        public LoanCardMasterEntity GetLoanCard(string id)
        {
            LoanCardMasterEntity loan_card = _dbconteact.LCMEntity.Find(id);
            return loan_card;
        }
        public List<LoanCardMasterEntity> GetLoanCards()
        {
            return _dbconteact.LCMEntity.ToList();
        }
        
    }
}
