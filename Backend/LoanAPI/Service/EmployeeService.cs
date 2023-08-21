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
        public List<EmployeeLoanCardDTO> GetEmployeesLoanCard(string id) {
            List<EmployeeCardDetailsEntity> Employee_Card = _dbconteact.ECDEntity.Where(i => i.Employee_Id.Equals(id)).ToList();
            List<EmployeeLoanCardDTO> Emp_loan_card = new List<EmployeeLoanCardDTO>();
            foreach (var loan_card in Employee_Card)
            {
                EmployeeLoanCardDTO loan_cardDTO = new EmployeeLoanCardDTO() { 
                    Loan_Id = loan_card.Loan_Id,
                    Loan_Type = _dbconteact.LCMEntity.Find(loan_card.Loan_Id).Loan_Type,
                    Duration = _dbconteact.LCMEntity.Find(loan_card.Loan_Id).Duration,
                    Card_Issue_Date =  loan_card.Card_Issue_Date,
                };
                Emp_loan_card.Add(loan_cardDTO);

            }
            return Emp_loan_card;

        }
        public List<EmployeeItemPurchaseDTO> GetEmployeesItemPurchase(string id)
        {
            List<EmployeeIssueDetailsEntity> Employee_Issue = _dbconteact.EIDEntity.Where(i => i.Employee_Id.Equals(id)).ToList();
            List<EmployeeItemPurchaseDTO> Emp_item_purchase = new List<EmployeeItemPurchaseDTO>();
            foreach (var emp_issue in Employee_Issue)
            {
                EmployeeItemPurchaseDTO item_purchaseDTO = new EmployeeItemPurchaseDTO()
                {
                    Issue_Id = emp_issue.Issue_Id,
                    Item_Description = _dbconteact.IMEntity.Find(emp_issue.Item_Id).Item_Description,
                    Item_Make= _dbconteact.IMEntity.Find(emp_issue.Item_Id).Item_Make,
                    Item_Category= _dbconteact.IMEntity.Find(emp_issue.Item_Id).Item_Category,
                    Item_Valuation= _dbconteact.IMEntity.Find(emp_issue.Item_Id).Item_Valuation,
                    
                };
                Emp_item_purchase.Add(item_purchaseDTO);

            }
            return Emp_item_purchase;

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