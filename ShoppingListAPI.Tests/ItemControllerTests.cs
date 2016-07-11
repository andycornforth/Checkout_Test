using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingListAPI.Controllers;
using ShoppingListAPI.Models;
using Moq;
using Repository;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Net.Http;

namespace ShoppingListAPI.Tests
{
    [TestClass]
    public class ItemControllerTests
    {
        private ItemController _itemController;
        private Mock<IItemRepository> _mockItemRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockItemRepository = new Mock<IItemRepository>();
            _itemController = new ItemController(_mockItemRepository.Object);
        }

        [TestMethod]
        public void AddItemToListExpectRepositoryCalledAnd200OK()
        {
            var item = new Item()
            {
                Name = "Pepsi",
                Quantity = 1
            };

            var result = _itemController.Post(item);

            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Repository.Models.Item>()), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Item>));
        }

        [TestMethod]
        public void AddNullItemToListExpect400BadRequest()
        {
            var result = _itemController.Post(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void AddNullNameInItemToListExpect400BadRequest()
        {
            var item = new Item()
            {
                Quantity = 1
            };

            var result = _itemController.Post(item);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void AddEmptyStringNameInItemToListExpect400BadRequest()
        {
            var item = new Item()
            {
                Name = string.Empty,
                Quantity = 1
            };

            var result = _itemController.Post(item);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void AddMinusQuantityInItemToListExpect400BadRequest()
        {
            var item = new Item()
            {
                Name = "Bread",
                Quantity = -1
            };

            var result = _itemController.Post(item);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateItemExpectRepositoryCalledAnd200OK()
        {
            var item = new Item()
            {
                Name = "Pepsi",
                Quantity = 1
            };

            var result = _itemController.Put(item);

            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Item>));
        }

        [TestMethod]
        public void UpdateNullExpect400BadRequest()
        {
            var result = _itemController.Put(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateNameEmptyStringExpect400BadRequest()
        {
            var item = new Item()
            {
                Name = string.Empty,
                Quantity = 1
            };

            var result = _itemController.Put(item);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateQuantityMinusNumberExpect400BadRequest()
        {
            var item = new Item()
            {
                Name = "Rum",
                Quantity = -1
            };

            var result = _itemController.Put(item);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteItemExpectRepositoryCalledAnd200Ok()
        {
            var result = _itemController.Delete("Cheese");

            _mockItemRepository.Verify(x => x.DeleteItem(It.IsAny<string>()), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<StringContent>));
        }

        [TestMethod]
        public void DeleteNullNameExpect400BadRequest()
        {
            var result = _itemController.Delete(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteEmptyStringNameExpect400BadRequest()
        {
            var result = _itemController.Delete(string.Empty);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public void GetItemExpectRepositoryCalledAndItemRetuned()
        {
            _mockItemRepository.Setup(x => x.GetItem(It.IsAny<string>())).Returns((string s) =>
               { return new Repository.Models.Item() { Name = s, Quantity = 5 }; });

            var result = _itemController.Get("Orange Juice");

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Item>));

            var item = (result as OkNegotiatedContentResult<Item>).Content;

            Assert.AreEqual("Orange Juice", item.Name);
            Assert.AreEqual(5, item.Quantity);
        }

        [TestMethod]
        public void GetNullItemExpect400BadRequest()
        {
            var result = _itemController.Get(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetemptyStringItemExpect400BadRequest()
        {
            var result = _itemController.Get(string.Empty);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetItemWhenRepositoryReturnsNullExpect404NotFound()
        {
            var result = _itemController.Get("Orange Juice");

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetListExpectListReturnedAnd200Ok()
        {
            _mockItemRepository.Setup(x => x.GetList()).Returns(new List<Repository.Models.Item>());

            var result = _itemController.GetList();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<Item>>));

            var list = (result as OkNegotiatedContentResult<List<Item>>).Content;

            Assert.IsInstanceOfType(list, typeof(List<Item>));
        }

        [TestMethod]
        public void ClearListExpectRepositoryCalledAnd200Ok()
        {
            _itemController.ClearList();

            _mockItemRepository.Verify(x => x.ClearList(), Times.Once);
        }
    }
}
