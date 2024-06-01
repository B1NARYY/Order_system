using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;

namespace PVfinal.Services
{
    public interface IItemStore
    {
        Task<IEnumerable<ItemModel>> GetItemsAsync();
        Task<bool> AddItemAsync(ItemModel item);
        Task<bool> UpdateItemAsync(ItemModel item);
        Task<bool> DeleteItemAsync(int id);
    }
}
