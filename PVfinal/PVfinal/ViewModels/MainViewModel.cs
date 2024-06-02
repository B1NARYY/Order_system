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
        private ObservableCollection<UserModel> _users;

        public MainViewModel()
        {
            _userService = new UserService();
            _users = new ObservableCollection<UserModel>();

            LoadUsersCommand = new Command(async () => await LoadUsersAsync());
            AddUserCommand = new Command(async (user) => await AddUserAsync(user as UserModel));
            RemoveUserCommand = new Command(async (userId) => await RemoveUserAsync((int)userId));
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public Command LoadUsersCommand { get; }
        public Command AddUserCommand { get; }
        public Command RemoveUserCommand { get; }

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
    }
}
