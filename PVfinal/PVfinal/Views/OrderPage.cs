using Xamarin.Forms;
using PVfinal.ViewModels;

namespace PVfinal.Views
{
    public class OrderPage : ContentPage
    {
        public OrderPage()
        {
            Title = "Order Details";
            BindingContext = new OrderViewModel();

            var collectionView = new CollectionView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var itemNameLabel = new Label();
                    itemNameLabel.SetBinding(Label.TextProperty, "ItemName");

                    var priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, new Binding("Price", stringFormat: "{0:C}"));

                    return new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { itemNameLabel, priceLabel }
                    };
                })
            };
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Items");

            Content = new StackLayout
            {
                Children = { collectionView }
            };
        }
    }
}
