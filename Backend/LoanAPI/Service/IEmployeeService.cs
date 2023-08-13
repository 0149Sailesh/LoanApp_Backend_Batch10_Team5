using LoanAPI.Entites;
using LOANAPI.Entites;

namespace LoanAPI.Service
{

    public interface IEmployeeService
    {
        void AddEmployee(EmployeeMastersEntity employee);
        List<EmployeeMastersEntity> GetEmployees();
        EmployeeMastersEntity GetEmployee(string id);
        void EditEmployee(EmployeeMastersEntity employee);
        void DeleteEmployee(string id);
    }
}
