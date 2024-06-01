using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PVfinal.Models;
using PVfinal.Services;
using Xamarin.Forms;

namespace PVfinal.ViewModels
{
    public class ItemViewModel : BindableObject
    {
        private ItemService _itemService;
        public ObservableCollection<ItemModel> Items { get; set; }

        public ItemViewModel()
        {
            _itemService = new ItemService();
            Items = new ObservableCollection<ItemModel>();
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await _itemService.GetItemsAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
