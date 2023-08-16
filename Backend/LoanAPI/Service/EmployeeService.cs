using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Models;
using LOANAPI.Entites;
using System.Collections.Generic;

namespace LoanAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LoanDbContext _dbconteact;

        public EmployeeService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddEmployee(EmployeeMasterDTO employeeDTO)
        {
            
        EmployeeMastersEntity employee = new EmployeeMastersEntity()
            {
                Employee_Id = employeeDTO.Employee_Id,
                Employee_Name= employeeDTO.Employee_Name,
                Employee_Gender= employeeDTO.Employee_Gender,
                Designation= employeeDTO.Designation,
                Department= employeeDTO.Department,
                Date_of_Birth= employeeDTO.Date_of_Birth,
                Date_of_Joining= employeeDTO.Date_of_Joining,
                Password = Guid.NewGuid().ToString(),
            };
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
            //EmployeeMastersEntity old_employee = _dbconteact.EMEntity.Find(employeeDTO.Employee_Id);
            //EmployeeMastersEntity employee = new EmployeeMastersEntity()
            //{
            //    Employee_Id = employeeDTO.Employee_Id,
            //    Employee_Name = employeeDTO.Employee_Name,
            //    Employee_Gender = employeeDTO.Employee_Gender,
            //    Designation = employeeDTO.Designation,
            //    Department = employeeDTO.Department,
            //    Date_of_Birth = employeeDTO.Date_of_Birth,
            //    Date_of_Joining = employeeDTO.Date_of_Joining,
            //    Password = _dbconteact.EMEntity.Find(employeeDTO.Employee_Id).Password,

            //};
            _dbconteact.EMEntity.Update(employee);
            _dbconteact.SaveChanges();
        }
        public EmployeeMasterDTO GetEmployee(string id)
        {
            EmployeeMastersEntity employee = _dbconteact.EMEntity.Find(id);
            EmployeeMasterDTO employeeDTO = new EmployeeMasterDTO()
            {
                Employee_Id = employee.Employee_Id,
                Employee_Name = employee.Employee_Name,
                Employee_Gender = employee.Employee_Gender,
                Designation = employee.Designation,
                Department = employee.Department,
                Date_of_Birth = employee.Date_of_Birth,
                Date_of_Joining = employee.Date_of_Joining
            };
            return employeeDTO;
        }
        public List<EmployeeMasterDTO> GetEmployees()
        {
            List<EmployeeMastersEntity> employees=_dbconteact.EMEntity.ToList();
            List<EmployeeMasterDTO> employeeDTOs = new List<EmployeeMasterDTO>();
            foreach (EmployeeMastersEntity employee in employees) {
                
                EmployeeMasterDTO employeeDTO = new EmployeeMasterDTO()
                {
                    Employee_Id = employee.Employee_Id,
                    Employee_Name = employee.Employee_Name,
                    Employee_Gender = employee.Employee_Gender,
                    Designation = employee.Designation,
                    Department = employee.Department,
                    Date_of_Birth = employee.Date_of_Birth,
                    Date_of_Joining = employee.Date_of_Joining
                };
                employeeDTOs.Add(employeeDTO);  
            }
            return employeeDTOs;
        }

    }
}