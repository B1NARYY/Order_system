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
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public Command LoadUsersCommand { get; }

        private async Task LoadUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
