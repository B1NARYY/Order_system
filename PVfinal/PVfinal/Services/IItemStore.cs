using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;

namespace PVfinal.Services
{
    public interface IItemStore
    {
        Task<IEnumerable<ItemModel>> GetItemsAsync();
        Task<ItemModel> GetItemAsync(int id);
        Task AddItemAsync(ItemModel item);
        Task UpdateItemAsync(ItemModel item);
        Task DeleteItemAsync(int id);
    }
}
