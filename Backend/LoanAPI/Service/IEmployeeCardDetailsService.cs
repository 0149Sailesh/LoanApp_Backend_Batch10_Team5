using LoanAPI.Entites;
//using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public interface IEmployeeCardDetailsService
    {
        void AddEmployeeCardDetails(EmployeeCardDetailsEntity ecd);
        //List<AdminEntity> GetAdmin();
        //AdminEntity GetAdmin(string id);
        List<EmployeeCardDetailsEntity> GetEmployeeCardDetails();
        EmployeeCardDetailsEntity GetEmployeeCardDetail(string id);
        void EditEmployeeCardDetails(EmployeeCardDetailsEntity ecd);
        void DeleteEmployeeCardDetails(string id);
    }
}
