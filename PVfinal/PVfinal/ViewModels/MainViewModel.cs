using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using PVfinal.Models;
using PVfinal.Services;

namespace PVfinal.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private readonly ItemService _itemService;
        private ObservableCollection<UserModel> _users;
        private ObservableCollection<ItemModel> _items;

        public MainViewModel()
        {
            _userService = new UserService();
            _itemService = new ItemService();
            _users = new ObservableCollection<UserModel>();
            _items = new ObservableCollection<ItemModel>();

            LoadUsersCommand = new Command(async () => await LoadUsersAsync());
            AddUserCommand = new Command(async (user) => await AddUserAsync(user as UserModel));
            RemoveUserCommand = new Command(async (userId) => await RemoveUserAsync((int)userId));

            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            AddItemCommand = new Command(async (item) => await AddItemAsync(item as ItemModel));
            RemoveItemCommand = new Command(async (itemId) => await RemoveItemAsync((int)itemId));
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public ObservableCollection<ItemModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Command LoadUsersCommand { get; }
        public Command AddUserCommand { get; }
        public Command RemoveUserCommand { get; }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command RemoveItemCommand { get; }

        private async Task LoadUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public async Task AddUserAsync(UserModel user)
        {
            await _userService.AddUserAsync(user);
            await LoadUsersAsync(); // Reload users to update the list
        }

        public async Task RemoveUserAsync(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            await LoadUsersAsync(); // Reload users to update the list
        }

        private async Task LoadItemsAsync()
        {
            var items = await _itemService.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public async Task AddItemAsync(ItemModel item)
        {
            await _itemService.AddItemAsync(item);
            await LoadItemsAsync(); // Reload items to update the list
        }

        public async Task RemoveItemAsync(int itemId)
        {
            await _itemService.DeleteItemAsync(itemId);
            await LoadItemsAsync(); // Reload items to update the list
        }
    }
}
