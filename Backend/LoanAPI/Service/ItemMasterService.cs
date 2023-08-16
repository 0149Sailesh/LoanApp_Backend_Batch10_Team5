using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Models;
using LOANAPI.Entites;

namespace LoanAPI.Service
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly LoanDbContext _dbconteact;

        public ItemMasterService(LoanDbContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddItem(ItemMasterEntity item)
        {

            _dbconteact.IMEntity.Add(item);
            _dbconteact.SaveChanges();
        }
        public void DeleteItem(string id)
        {
            ItemMasterEntity item = _dbconteact.IMEntity.Find(id);
            _dbconteact.IMEntity.Remove(item);
            _dbconteact.SaveChanges();

        }
        public void EditItem(ItemMasterEntity item)
        {
            _dbconteact.IMEntity.Update(item);
            _dbconteact.SaveChanges();
        }
        public ItemMasterEntity GetItem(string id)
        {
            ItemMasterEntity item = _dbconteact.IMEntity.Find(id);
            return item;
        }
        public List<ItemMasterEntity> GetItems()
        {
            return _dbconteact.IMEntity.ToList();
        }

    }
}
