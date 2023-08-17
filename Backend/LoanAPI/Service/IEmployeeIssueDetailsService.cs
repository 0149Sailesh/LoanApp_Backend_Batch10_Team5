using LoanAPI.Entites;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public interface IEmployeeIssueDetailsService
    {
        void AddEmployeeIssueDetails(EmployeeIssueDetailsEntity esd);
        //List<AdminEntity> GetAdmin();
        //AdminEntity GetAdmin(string id);
        List<EmployeeIssueDetailsEntity> GetEmployeeIssueDetails();
        EmployeeIssueDetailsEntity GetEmployeeIssueDetail(string id);
        void EditEmployeeIssueDetails(EmployeeIssueDetailsEntity esd);
        void DeleteEmployeeIssueDetails(string id);
    }
}
