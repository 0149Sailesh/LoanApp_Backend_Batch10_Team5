using LoanAPI.Entites;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public class EmployeeCardDetailsService : IEmployeeCardDetailsService
    {
        private readonly LoanDbContext _dbconteact;

        public EmployeeCardDetailsService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddEmployeeCardDetails(EmployeeCardDetailsEntity ecd)
        {
            //Console.WriteLine("Enter into ecd Service");
            _dbconteact.ECDEntity.Add(ecd);
            _dbconteact.SaveChanges();
        }

        public void DeleteEmployeeCardDetails(string id)
        {
            EmployeeCardDetailsEntity ecd = _dbconteact.ECDEntity.Find(id);
            _dbconteact.ECDEntity.Remove(ecd);
            _dbconteact.SaveChanges();

        }
        public void EditEmployeeCardDetails(EmployeeCardDetailsEntity ecd)
        {
            _dbconteact.ECDEntity.Update(ecd);
            _dbconteact.SaveChanges();
        }

        public List<EmployeeCardDetailsEntity> GetEmployeeCardDetails()
        {
            return _dbconteact.ECDEntity.ToList();
        }
        public EmployeeCardDetailsEntity GetEmployeeCardDetail(string id)
        {
            EmployeeCardDetailsEntity ecd = _dbconteact.ECDEntity.Find(id);
            return ecd;
        }
    }
}
