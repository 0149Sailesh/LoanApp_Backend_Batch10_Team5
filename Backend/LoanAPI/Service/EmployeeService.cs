using LoanAPI.Entites;
using LoanAPI.Models;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LoanDbContext _dbconteact;

        public EmployeeService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddEmployee(EmployeeMastersEntity employee)
        {
            _dbconteact.EMEntity.Add(employee);
            _dbconteact.SaveChanges();
        }

        public void DeleteEmployee(string id)
        {
            EmployeeMastersEntity employee = _dbconteact.EMEntity.Find(id);
            _dbconteact.EMEntity.Remove(employee);
            _dbconteact.SaveChanges();

        }
        public void EditEmployee(EmployeeMastersEntity employee)
        {
            _dbconteact.EMEntity.Update(employee);
            _dbconteact.SaveChanges();
        }
        public EmployeeMastersEntity GetEmployee(string id)
        {
            EmployeeMastersEntity employee = _dbconteact.EMEntity.Find(id);
            return employee;
        }
        public List<EmployeeMastersEntity> GetEmployees()
        {
            return _dbconteact.EMEntity.ToList();
        }

    }
}