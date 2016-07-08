using System.Web.Http;
using ShoppingListAPI.Models;
using Repository;
using ShoppingListAPI.Helpers;

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
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(string name, int quantity)
        {
            if (name == null || name.Equals(string.Empty) || quantity < 0)
                return BadRequest();

            _itemRepository.UpdateItem(name, quantity);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            if (name == null || name.Equals(string.Empty))
                return BadRequest();

            _itemRepository.DeleteItem(name);
            return Ok();
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
    }
}
