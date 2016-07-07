using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingListAPI.Controllers;
using ShoppingListAPI.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace ShoppingListAPI.Tests
{
    [TestClass]
    public class ListControllerTests
    {
        private ListController _listController;

        [TestMethod]
        public void GetListWith0EntriesExpectEmptyListReturned()
        {
            _listController = new ListController();

            var actionResult = _listController.Get();

            var result = actionResult as OkNegotiatedContentResult<List>;

            Assert.AreEqual(0, result.Content.Items.Count);
        }
    }
}
