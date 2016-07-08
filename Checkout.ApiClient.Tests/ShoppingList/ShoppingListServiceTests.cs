using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Checkout.ApiServices.SharedModels;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListTests : BaseServiceTests
    {
        [TearDown]
        public void TearDown()
        {
            CheckoutClient.ShoppingListService.ClearList();
        }

        [Test]
        public void AddItem()
        {
            var response = AddItemToList("Test_Product", 2);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetItem()
        {
            var name = "Test";
            AddItemToList(name, 1);

            var response = CheckoutClient.ShoppingListService.GetItem(name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().BeOfType(typeof(Product));
            response.Model.Name.Should().Be("Test");
            response.Model.Quantity.Should().Be(1);
        }

        [Test]
        public void DeleteItem()
        {
            var name = "Test";
            AddItemToList(name, 1);

            var response = CheckoutClient.ShoppingListService.DeleteItem(name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void UpdateItem()
        {
            var name = "Test";
            AddItemToList(name, 1);

            var response = CheckoutClient.ShoppingListService.UpdateItem(new Product() { Name = name, Quantity = 5 });

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetList()
        {
            AddItemToList("Test_Product", 2);
            AddItemToList("Test_Product_2", 10);

            var response = CheckoutClient.ShoppingListService.GetList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().BeOfType(typeof(List<Product>));
            response.Model.Count.Should().Be(2);
        }

        private HttpResponse<OkResponse> AddItemToList(string name, int quantity)
        {
            var item = new Product()
            {
                Name = name,
                Quantity = quantity
            };
            return CheckoutClient.ShoppingListService.AddItem(item);
        }
    }
}
