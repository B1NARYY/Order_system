using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;
using PVfinal.DAO;

namespace PVfinal.Services
{
    public class ItemService
    {
        public async Task<IEnumerable<ItemModel>> GetItemsAsync()
        {
            return await Task.Run(() => ItemDAO.GetAllItems());
        }

        public async Task<ItemModel> GetItemAsync(int id)
        {
            return await Task.Run(() => ItemDAO.GetItem(id));
        }

        public async Task AddItemAsync(ItemModel item)
        {
            await Task.Run(() => ItemDAO.AddItem(item));
        }

        public async Task UpdateItemAsync(ItemModel item)
        {
            await Task.Run(() => ItemDAO.UpdateItem(item));
        }

        public async Task DeleteItemAsync(int id)
        {
            await Task.Run(() => ItemDAO.DeleteItem(id));
        }
    }
}
