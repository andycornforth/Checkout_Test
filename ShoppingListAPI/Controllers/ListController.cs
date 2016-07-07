using ShoppingListAPI.Models;
using System.Web.Http;

namespace ShoppingListAPI.Controllers
{
    public class ListController : ApiController
    {

        public ListController()
        {
        }

        public IHttpActionResult Get()
        {
            return Ok(new List() { Items = new System.Collections.Generic.List<Item>() });
        }
    }
}
