﻿using LoanAPI.DTOs;
using LoanAPI.Entites;
using LoanAPI.Service;
using LOANAPI.Entites;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin")]
        public IActionResult Add(ItemMasterEntity item)
        {
            try
            {

                Item.AddItem(item);
                return StatusCode(200, new JsonResult(item,"Item Added"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAllItems")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetAll()
        {
            List<ItemMasterEntity> items = Item.GetItems();
            try
            {
                return StatusCode(200, items);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetItem/{id}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetItem(string id)
        {
            try
            {
                ItemMasterEntity item = Item.GetItem(id);
                return StatusCode(200, item);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditItem")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(ItemMasterEntity item)
        {
            try
            {
                Item.EditItem(item);
                return StatusCode(200, new JsonResult("Item Updated"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteItem/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                Item.DeleteItem(id);
                return StatusCode(200, new JsonResult("Item Deleted"));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
