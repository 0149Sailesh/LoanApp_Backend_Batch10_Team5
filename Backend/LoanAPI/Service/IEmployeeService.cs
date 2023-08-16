using LoanAPI.Entites;
using LOANAPI.Entites;
using LoanAPI.DTOs;
namespace LoanAPI.Service
{

    public interface IEmployeeService
    {
        void AddEmployee(EmployeeMasterDTO employeeDTO);
        List<EmployeeMasterDTO> GetEmployees();
        EmployeeMasterDTO GetEmployee(string id);
        void EditEmployee(EmployeeMastersEntity employee);
        void DeleteEmployee(string id);
    }
}
