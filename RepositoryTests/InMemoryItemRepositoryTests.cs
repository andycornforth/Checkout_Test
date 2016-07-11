using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System.Collections.Generic;
using Repository.Models;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class InMemoryItemRepositoryTests
    {
        private IItemRepository _inMemoryItemRepository;

        [TestInitialize]
        public void Initialize()
        {
            _inMemoryItemRepository = new InMemoryItemRepository();
        }

        [TestMethod]
        public void GetListWithNoEntriesExpectEmptyListReturned()
        {
            var list = _inMemoryItemRepository.GetList();

            Assert.IsInstanceOfType(list, typeof(List<Item>));
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void AddItemExpectItemAdded()
        {
            AddTestItem("Water", 4);

            var list = _inMemoryItemRepository.GetList();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Water", list.FirstOrDefault().Name);
            Assert.AreEqual(4, list.FirstOrDefault().Quantity);
        }

        [TestMethod]
        public void AddDuplicateNamedItemExpectOnly1EntryWithTheSumOfQuantites()
        {
            AddTestItem("Water", 4);
            AddTestItem("Water", 6);

            var list = _inMemoryItemRepository.GetList();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Water", list.FirstOrDefault().Name);
            Assert.AreEqual(10, list.FirstOrDefault().Quantity);
        }

        [TestMethod]
        public void Add3ItemsExpect3ItemsInTheList()
        {
            AddTestItem("Water", 4);
            AddTestItem("Coca Cola", 1);
            AddTestItem("Beer", 2);

            var list = _inMemoryItemRepository.GetList();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetItemFromListOf1ExpectItemReturned()
        {
            var name = "Water";
            var quantity = 4;
            AddTestItem(name, quantity);

            var item = _inMemoryItemRepository.GetItem(name);

            Assert.IsInstanceOfType(item, typeof(Item));
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(quantity, item.Quantity);
        }

        [TestMethod]
        public void GetItemFromListOfMultipleItemsExpectCorrectItemReturned()
        {
            var name = "Water";
            var quantity = 4;
            AddTestItem(name, quantity);
            AddTestItem("Coca Cola", 1);

            var item = _inMemoryItemRepository.GetItem(name);

            Assert.IsInstanceOfType(item, typeof(Item));
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(quantity, item.Quantity);
        }

        [TestMethod]
        public void GetItemFromEmptyListxpectNullReturned()
        {
            var name = "Water";

            var item = _inMemoryItemRepository.GetItem(name);

            Assert.IsNull(item);
        }

        [TestMethod]
        public void DeleteDrinkExpectDrinkDeleted()
        {
            var name = "Water";
            var quantity = 4;
            AddTestItem(name, quantity);

            var item = _inMemoryItemRepository.GetItem(name);
            Assert.IsInstanceOfType(item, typeof(Item));

            _inMemoryItemRepository.DeleteItem(name);

            item = _inMemoryItemRepository.GetItem(name);
            Assert.IsNull(item);
        }

        [TestMethod]
        public void DeleteDrinkWhenItDoesNotExistExpectNoDifference()
        {
            var name = "Water";
            var quantity = 4;
            AddTestItem(name, quantity);

            var item = _inMemoryItemRepository.GetItem(name);
            Assert.IsInstanceOfType(item, typeof(Item));

            _inMemoryItemRepository.DeleteItem("Coca Cola");

            item = _inMemoryItemRepository.GetItem(name);
            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod]
        public void UpdateDrinkQuantiyExpectQuantityUpdate()
        {
            var name = "Water";
            AddTestItem(name, 4);

            _inMemoryItemRepository.UpdateItem(name, 5);

            var item = _inMemoryItemRepository.GetItem(name);

            Assert.AreEqual(5, item.Quantity);
        }

        [TestMethod]
        public void UpdateDrinkQuantiyWhereItemDoesNotExistNoEXceptionIsThrown()
        {
            _inMemoryItemRepository.UpdateItem("Water", 5);
        }

        [TestMethod]
        public void ClearListExpectListCleared()
        {
            AddTestItem("Lemonade", 1);

            _inMemoryItemRepository.ClearList();

            var list = _inMemoryItemRepository.GetList();

            Assert.AreEqual(0, list.Count);
        }

        private void AddTestItem(string name, int quantity)
        {
            _inMemoryItemRepository.AddItem(
                new Item()
                {
                    Name = name,
                    Quantity = quantity
                });
        }
    }
}
