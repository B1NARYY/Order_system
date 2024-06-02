using Xamarin.Forms;
using PVfinal.ViewModels;
using PVfinal.Models;

namespace PVfinal.Views
{
    public class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;

            Title = "Zákazníci";

            var usersListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Username");

                    var balanceLabel = new Label();
                    balanceLabel.SetBinding(Label.TextProperty, new Binding("Balance", stringFormat: "{0:C}"));

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = { nameLabel, balanceLabel }
                        }
                    };
                })
            };
            usersListView.SetBinding(ListView.ItemsSourceProperty, nameof(MainViewModel.Users));
            usersListView.ItemTapped += OnUserTapped;

            var addButton = new Button
            {
                Text = "Přidat zákazníka",
                Command = new Command(OnAddUser)
            };

            var removeButton = new Button
            {
                Text = "Odebrat zákazníka",
                Command = new Command(OnRemoveUser)
            };

            Content = new StackLayout
            {
                Children =
                {
                    usersListView,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { addButton, removeButton }
                    }
                }
            };

            _viewModel.LoadUsersCommand.Execute(null);
        }

        private async void OnUserTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is UserModel user)
            {
                await Navigation.PushAsync(new OrderPage(user));
            }
        }

        private async void OnAddUser()
        {
            string username = await DisplayPromptAsync("Přidat zákazníka", "Zadejte jméno zákazníka:");
            if (!string.IsNullOrEmpty(username))
            {
                var newUser = new UserModel { Username = username, Balance = 0 };
                await _viewModel.AddUserAsync(newUser);
            }
        }

        private async void OnRemoveUser()
        {
            string userIdStr = await DisplayPromptAsync("Odebrat zákazníka", "Zadejte ID zákazníka, kterého chcete odebrat:");
            if (int.TryParse(userIdStr, out int userId))
            {
                await _viewModel.RemoveUserAsync(userId);
            }
        }
    }
}
