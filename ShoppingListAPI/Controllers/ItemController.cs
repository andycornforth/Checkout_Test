using System.Web.Http;
using ShoppingListAPI.Models;
using Repository;
using ShoppingListAPI.Helpers;
using System.Net.Http;
using System;

namespace ShoppingListAPI.Controllers
{
    public class ItemController : ApiController
    {
        private IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public IHttpActionResult Post(Item item)
        {
            if (item == null || item.Name == null || item.Name.Equals(string.Empty) || item.Quantity < 0)
                return BadRequest();

            _itemRepository.AddItem(ItemMapper.APIToRepository(item));
            return Ok(item);
        }

        [HttpPut]
        public IHttpActionResult Put(Item item)
        {
            if (item == null || item.Name == null || item.Name.Equals(string.Empty) || item.Quantity < 0)
                return BadRequest();

            _itemRepository.UpdateItem(item.Name, item.Quantity);
            return Ok(item);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            if (name == null || name.Equals(string.Empty))
                return BadRequest();

            _itemRepository.DeleteItem(name);
            return Ok(new StringContent($"{name} deleted."));
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            if (name == null || name.Equals(string.Empty))
                return BadRequest();

            var item = _itemRepository.GetItem(name);

            if (item == null)
                return NotFound();

            return Ok(ItemMapper.RepositoryToAPI(item));
        }

        [HttpGet]
        public IHttpActionResult GetList() => Ok(ItemMapper.RepositoryListToAPIList(_itemRepository.GetList()));

        [HttpGet]
        public IHttpActionResult ClearList()
        {
            _itemRepository.ClearList();
            return Ok();
        }
    }
}
