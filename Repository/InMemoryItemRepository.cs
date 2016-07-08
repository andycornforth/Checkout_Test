using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Repository
{
    public class InMemoryItemRepository : IItemRepository
    {
        private List<Item> _list;

        public InMemoryItemRepository()
        {
            _list = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!_list.Any(x => x.Name == item.Name))
                _list.Add(item);
            else
                UpdateItem(item.Name, item.Quantity + _list.Where(x => x.Name == item.Name).FirstOrDefault().Quantity);
        }

        public void ClearList()
        {
            _list.Clear();
        }

        public void DeleteItem(string name) => _list.RemoveAll(x => x.Name == name);

        public Item GetItem(string name) => _list.Where(x => x.Name == name).FirstOrDefault();

        public IList<Item> GetList() => _list;

        public void UpdateItem(string name, int quantity)
        {
            var item = _list.Where(x => x.Name == name).FirstOrDefault();

            if (item != null)
                item.Quantity = quantity;
        }
    }
}
