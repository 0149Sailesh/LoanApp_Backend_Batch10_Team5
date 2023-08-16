using LoanAPI.Entites;
using LOANAPI.Entites;
using LoanAPI.DTOs;
namespace LoanAPI.Service
{
    public interface IItemMasterService
    {
        void AddItem(ItemMasterEntity item);
        List<ItemMasterEntity> GetItems();
        ItemMasterEntity GetItem(string id);
        void EditItem(ItemMasterEntity item);
        void DeleteItem(string id);


    }
}
