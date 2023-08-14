using LoanAPI.Entites;
using LoanAPI.Models;

namespace LoanAPI.Service
{
    public class AdminService : IAdminService
    {
        private readonly LoanDbContext _dbconteact;

        public AdminService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddAdmin(AdminEntity Admin)
        {
            Console.WriteLine("Enter into Admin Service");
            _dbconteact.AdminEntity.Add(Admin);
            _dbconteact.SaveChanges();
        }

        public void DeleteAdmin(string id)
        {
            AdminEntity Admin = _dbconteact.AdminEntity.Find(id);
            _dbconteact.AdminEntity.Remove(Admin);
            _dbconteact.SaveChanges();

        }
        public void EditAdmin(AdminEntity Admin)
        {
            _dbconteact.AdminEntity.Update(Admin);
            _dbconteact.SaveChanges();
        }
        
        public List<AdminEntity> GetAdmins()
        {
            return _dbconteact.AdminEntity.ToList();
        } 
        public AdminEntity GetAdmin(string id)
        {
            AdminEntity Admin = _dbconteact.AdminEntity.Find(id);
            return Admin;
        }
       

        /*void IAdminService.AddAdmin(AdminEntity admin)
        {
            throw new NotImplementedException();
        }*/
        //void IAdminService.DeleteAdmin(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //void IAdminService.EditAdmin(AdminEntity admin)
        //{
        //    throw new NotImplementedException();
        //}

        //List<AdminEntity> IAdminService.GetAdmins()
        //{
        //    throw new NotImplementedException();
        //}

        
        //AdminEntity IAdminService.GetAdmin(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
