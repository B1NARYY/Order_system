using PVfinal.Models;
using PVfinal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PVfinal.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private readonly UserService _userService;
        public ObservableCollection<UserModel> Users { get; }

        public MainViewModel()
        {
            _userService = new UserService();
            Users = new ObservableCollection<UserModel>();
            LoadUsersAsync();
        }

        private async void LoadUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
