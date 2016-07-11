using ShoppingListAPI.Models;
using System.Collections.Generic;

namespace ShoppingListAPI.Helpers
{
    public static class ItemMapper
    {
        public static Repository.Models.Item APIToRepository(Item item)
        {
            return new Repository.Models.Item()
            {
                Name = item.Name,
                Quantity = item.Quantity
            };
        }

        public static Item RepositoryToAPI(Repository.Models.Item item)
        {
            return new Item()
            {
                Name = item.Name,
                Quantity = item.Quantity
            };
        }

        public static List<Item> RepositoryListToAPIList(IList<Repository.Models.Item> list)
        {
            var apiList = new List<Item>();

            foreach (var item in list)
            {
                apiList.Add(new Item()
                {
                    Name = item.Name,
                    Quantity = item.Quantity
                });
            }

            return apiList;
        }
    }
}