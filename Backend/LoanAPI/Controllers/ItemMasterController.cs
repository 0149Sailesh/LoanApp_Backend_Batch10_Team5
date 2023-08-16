using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : ControllerBase
    {
        private readonly IItemMasterService Item;
        public ItemMasterController(IItemMasterService item)
        {
            this.Item = item;
        }

        [HttpPost, Route("RegisterItem")]
        public IActionResult Add(ItemMasterEntity item)
        {
            try
            {

                Item.AddItem(item);
                return StatusCode(200, new JsonResult("Item Added"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("GetAllItems")]
        public IActionResult GetAll()
        {
            List<ItemMasterEntity> items = Item.GetItems();
            try
            {
                return StatusCode(200, items);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetItem/{id}")]
        public IActionResult GetItem(string id)
        {
            try
            {
                ItemMasterEntity item = Item.GetItem(id);
                return StatusCode(200, item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditItem")]
        public IActionResult Update(ItemMasterEntity item)
        {
            try
            {
                Item.EditItem(item);
                return StatusCode(200, new JsonResult("Item Updated"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteItem/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Item.DeleteItem(id);
                return StatusCode(200, new JsonResult("Item Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
