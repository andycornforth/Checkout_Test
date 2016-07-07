using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Controllers
{
    public class ItemController : ApiController
    {
        public ItemController()
        {
        }

        public IHttpActionResult Post(Item item)
        {
            return Ok();
        }
    }
}
