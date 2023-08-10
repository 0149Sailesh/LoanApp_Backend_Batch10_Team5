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
        public AdminEntity GetAdmin(string id)
        {
            AdminEntity Admin = _dbconteact.AdminEntity.Find(id);
            return Admin;
        }
        public List<AdminEntity> GetAdmins()
        {
            return _dbconteact.AdminEntity.ToList();
        }

        void IAdminService.AddAdmin(AdminEntity admin)
        {
            throw new NotImplementedException();
        }

        void IAdminService.DeleteAdmin(string id)
        {
            throw new NotImplementedException();
        }

        void IAdminService.EditAdmin(AdminEntity admin)
        {
            throw new NotImplementedException();
        }

        List<AdminEntity> IAdminService.GetAdmin()
        {
            throw new NotImplementedException();
        }

        AdminEntity IAdminService.GetAdmin(string id)
        {
            throw new NotImplementedException();
        }
    }
}

/*public List<AdminModel> GetAdminswithProject()
        {
            try
            {
                List<AdminModel> AdminModels = (from e in _dbconteact.AdminEntitys
                                                      join p in _dbconteact.Projects
                                                      on e.ProjectCode equals p.ProjectCode
                                                      select new AdminModel()
                                                      {
                                                          Id = e.Id,
                                                          Name = e.Name,
                                                          Project = p.ProjectName
                                                      }).ToList();
                return AdminModels;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Entities.AdminModel> GetAdminwithProject()
        {
            throw new NotImplementedException();
        }

        Entities.AdminModel IAdminService.GetAdmin(string id)
        {
            throw new NotImplementedException();
        }
    }

    public class AdminEntity
    {
    }*/