using Repository.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        IList<Item> GetList();
        Item GetItem(string name);
        void DeleteItem(string name);
        void UpdateItem(string name, int quantity);
    }
}
