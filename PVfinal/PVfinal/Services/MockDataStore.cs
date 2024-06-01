using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PVfinal.Models;

namespace PVfinal.Services
{
    public class MockDataStore : IItemStore
    {
        private readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = 1, ItemName = "Notebook", Price = 999.99m },
                new ItemModel { Id = 2, ItemName = "Pen", Price = 2.99m },
                new ItemModel { Id = 3, ItemName = "Eraser", Price = 1.49m }
            };
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync()
        {
            // Simulování asynchronní operace
            return await Task.FromResult(items);
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem == null) return await Task.FromResult(false);
            existingItem.ItemName = item.ItemName;
            existingItem.Price = item.Price;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return await Task.FromResult(false);
            items.Remove(item);
            return await Task.FromResult(true);
        }
    }
}
