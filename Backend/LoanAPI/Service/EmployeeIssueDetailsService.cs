using LoanAPI.Entites;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public class EmployeeIssueDetailsService : IEmployeeIssueDetailsService
    {
        private readonly LoanDbContext _dbconteact;

        public EmployeeIssueDetailsService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddEmployeeIssueDetails(EmployeeIssueDetailsEntity esd)
        {
            Console.WriteLine("Enter into esd Service");
            _dbconteact.EIDEntity.Add(esd);
            _dbconteact.SaveChanges();
        }

        public void DeleteEmployeeIssueDetails(string id)
        {
            EmployeeIssueDetailsEntity esd = _dbconteact.EIDEntity.Find(id);
            _dbconteact.EIDEntity.Remove(esd);
            _dbconteact.SaveChanges();

        }
        public void EditEmployeeIssueDetails(EmployeeIssueDetailsEntity esd)
        {
            _dbconteact.EIDEntity.Update(esd);
            _dbconteact.SaveChanges();
        }

        public List<EmployeeIssueDetailsEntity> GetEmployeeIssueDetails()
        {
            return _dbconteact.EIDEntity.ToList();
        }
        public EmployeeIssueDetailsEntity GetEmployeeIssueDetail(string id)
        {
            EmployeeIssueDetailsEntity esd = _dbconteact.EIDEntity.Find(id);
            return esd;
        }
    }
}
