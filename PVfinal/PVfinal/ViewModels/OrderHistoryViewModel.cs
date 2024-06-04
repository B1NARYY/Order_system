using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using PVfinal.Models;
using PVfinal.Services;

namespace PVfinal.ViewModels
{
    public class OrderHistoryViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        private UserModel _selectedUser;
        private ObservableCollection<OrderModel> _orders;

        public OrderHistoryViewModel(UserModel selectedUser)
        {
            _orderService = new OrderService();
            _selectedUser = selectedUser;
            _orders = new ObservableCollection<OrderModel>();

            LoadOrdersCommand = new Command(async () => await LoadOrdersAsync());
        }

        public ObservableCollection<OrderModel> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }

        public Command LoadOrdersCommand { get; }

        private async Task LoadOrdersAsync()
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(_selectedUser.Id);
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
    }
}
