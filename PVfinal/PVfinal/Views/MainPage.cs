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

            Title = "Main Page";

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

            Content = new StackLayout
            {
                Children = { usersListView }
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
    }
}
