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

            Title = "Položky";

            var itemsListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "ItemName");

                    var priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, new Binding("Price", stringFormat: "{0:C}"));

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = { nameLabel, priceLabel }
                        }
                    };
                })
            };
            itemsListView.SetBinding(ListView.ItemsSourceProperty, nameof(MainViewModel.Items));

            var addButton = new Button
            {
                Text = "Přidat položku",
                Command = new Command(OnAddItem)
            };

            var removeButton = new Button
            {
                Text = "Odebrat položku",
                Command = new Command(OnRemoveItem)
            };

            Content = new StackLayout
            {
                Children =
                {
                    itemsListView,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { addButton, removeButton }
                    }
                }
            };

            _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void OnAddItem()
        {
            string itemName = await DisplayPromptAsync("Přidat položku", "Zadejte název položky:");
            string priceStr = await DisplayPromptAsync("Přidat položku", "Zadejte cenu položky:", keyboard: Keyboard.Numeric);

            if (!string.IsNullOrEmpty(itemName) && decimal.TryParse(priceStr, out decimal price))
            {
                var newItem = new ItemModel { ItemName = itemName, Price = price };
                await _viewModel.AddItemAsync(newItem);
            }
        }

        private async void OnRemoveItem()
        {
            string itemIdStr = await DisplayPromptAsync("Odebrat položku", "Zadejte ID položky, kterou chcete odebrat:");
            if (int.TryParse(itemIdStr, out int itemId))
            {
                await _viewModel.RemoveItemAsync(itemId);
            }
        }
    }
}
