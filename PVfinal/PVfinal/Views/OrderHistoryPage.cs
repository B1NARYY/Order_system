using Xamarin.Forms;
using PVfinal.ViewModels;
using PVfinal.Models;

namespace PVfinal.Views
{
    public class OrderHistoryPage : ContentPage
    {
        private readonly OrderHistoryViewModel _viewModel;

        public OrderHistoryPage(UserModel selectedUser)
        {
            _viewModel = new OrderHistoryViewModel(selectedUser);
            BindingContext = _viewModel;

            Title = "Historie objednávek";

            var ordersListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var orderDateLabel = new Label();
                    orderDateLabel.SetBinding(Label.TextProperty, "OrderDate");

                    var orderTotalLabel = new Label();
                    orderTotalLabel.SetBinding(Label.TextProperty, "Total");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = { orderDateLabel, orderTotalLabel }
                        }
                    };
                })
            };
            ordersListView.SetBinding(ListView.ItemsSourceProperty, nameof(OrderHistoryViewModel.Orders));
            ordersListView.ItemTapped += OnOrderTapped;

            Content = new StackLayout
            {
                Children = { ordersListView }
            };

            _viewModel.LoadOrdersCommand.Execute(null);
        }

        private async void OnOrderTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OrderModel order)
            {
                // Můžete přidat zobrazení detailů objednávky zde
                await DisplayAlert("Detail objednávky", $"Objednávka {order.Id} z {order.OrderDate}", "OK");
            }
        }
    }
}
