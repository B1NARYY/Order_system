using Xamarin.Forms;
using PVfinal.ViewModels;

namespace PVfinal.Views
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Main Page";
            BindingContext = new MainViewModel();

            var collectionView = new CollectionView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Username");

                    var balanceLabel = new Label();
                    balanceLabel.SetBinding(Label.TextProperty, new Binding("Balance", stringFormat: "{0:C}"));

                    return new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { nameLabel, balanceLabel }
                    };
                })
            };
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Users");

            Content = new StackLayout
            {
                Children = { collectionView }
            };
        }
    }
}
