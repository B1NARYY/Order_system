using Xamarin.Forms;
using PVfinal.ViewModels;
using PVfinal.Models;

namespace PVfinal.Views
{
    public class OrderPage : ContentPage
    {
        private readonly OrderViewModel _viewModel;

        public OrderPage(UserModel selectedUser)
        {
            _viewModel = new OrderViewModel(selectedUser);
            BindingContext = _viewModel;

            Title = "New Order";

            var itemsListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var itemNameLabel = new Label();
                    itemNameLabel.SetBinding(Label.TextProperty, "ItemName");

                    var priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, new Binding("Price", stringFormat: "{0:C}"));

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = { itemNameLabel, priceLabel }
                        }
                    };
                })
            };
            itemsListView.SetBinding(ListView.ItemsSourceProperty, nameof(OrderViewModel.Items));
            itemsListView.ItemTapped += OnItemTapped;

            var addButton = new Button
            {
                Text = "Add Order",
                Command = _viewModel.AddOrderCommand
            };

            Content = new StackLayout
            {
                Children = { itemsListView, addButton }
            };

            _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ItemModel item)
            {
                string quantityStr = await DisplayPromptAsync("Quantity", "Enter quantity:", initialValue: "1", keyboard: Keyboard.Numeric);
                if (int.TryParse(quantityStr, out int quantity))
                {
                    _viewModel.AddOrderItem(item, quantity);
                }
            }
        }
    }
}
