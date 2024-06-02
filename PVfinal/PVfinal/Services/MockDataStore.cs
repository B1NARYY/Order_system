using System;
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
                new ItemModel { Id = 1, ItemName = "First item", Price = 9.99m },
                new ItemModel { Id = 2, ItemName = "Second item", Price = 19.99m },
                // Další položky...
            };
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<ItemModel> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(i => i.Id == id));
        }

        public async Task AddItemAsync(ItemModel item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.FirstOrDefault(i => i.Id == item.Id);
            if (oldItem != null)
            {
                oldItem.ItemName = item.ItemName;
                oldItem.Price = item.Price;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
            await Task.CompletedTask;
        }
    }
}
