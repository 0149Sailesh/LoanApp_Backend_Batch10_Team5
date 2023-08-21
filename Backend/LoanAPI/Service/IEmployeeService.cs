using LoanAPI.Entites;
using LOANAPI.Entites;
using LoanAPI.DTOs;
namespace LoanAPI.Service
{

    public interface IEmployeeService
    {
        void AddEmployee(EmployeeMasterDTO employeeDTO);
        List<EmployeeMasterDTO> GetEmployees();
        List<EmployeeLoanCardDTO> GetEmployeesLoanCard(string id);
        List<EmployeeItemPurchaseDTO> GetEmployeesItemPurchase(string id);
        EmployeeMasterDTO GetEmployee(string id);
        void EditEmployee(EmployeeMastersEntity employee);
        void DeleteEmployee(string id);
    }
}
