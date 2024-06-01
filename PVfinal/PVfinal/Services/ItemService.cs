using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVfinal.Services
{
    public class ItemService
    {

        public Task<List<ItemModel>> GetItemsAsync()
        {
            // Simulace získání položek z databáze
            return Task.FromResult(new List<ItemModel>
            {
                new ItemModel { Id = 1, ItemName = "Notebook", Price = 1200.99m },
                new ItemModel { Id = 2, ItemName = "Pen", Price = 3.45m }
            });
        }
    }
}
