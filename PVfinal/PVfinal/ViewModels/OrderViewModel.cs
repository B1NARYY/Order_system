using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using PVfinal.Models;
using PVfinal.Services;
using System.Collections.Generic;

namespace PVfinal.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        private readonly ItemService _itemService;
        private UserModel _selectedUser;
        private ObservableCollection<ItemModel> _items;
        private ObservableCollection<OrderItemModel> _orderItems;

        public OrderViewModel(UserModel selectedUser)
        {
            _orderService = new OrderService();
            _itemService = new ItemService();
            _selectedUser = selectedUser;
            _items = new ObservableCollection<ItemModel>();
            _orderItems = new ObservableCollection<OrderItemModel>();

            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            AddOrderCommand = new Command(async () => await AddOrderAsync());
        }

        public ObservableCollection<ItemModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ObservableCollection<OrderItemModel> OrderItems
        {
            get => _orderItems;
            set => SetProperty(ref _orderItems, value);
        }

        public Command LoadItemsCommand { get; }
        public Command AddOrderCommand { get; }

        private async Task LoadItemsAsync()
        {
            var items = await _itemService.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async Task AddOrderAsync()
        {
            var newOrder = new OrderModel
            {
                UserId = _selectedUser.Id,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItemModel>(_orderItems) 
            };

            await _orderService.AddOrderAsync(newOrder);
        }

        public void AddOrderItem(ItemModel item, int quantity)
        {
            var orderItem = new OrderItemModel
            {
                ItemId = item.Id,
                Quantity = quantity
            };
            OrderItems.Add(orderItem);
        }
    }
}
