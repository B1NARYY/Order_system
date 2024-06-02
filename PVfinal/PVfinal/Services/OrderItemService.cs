using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;
using PVfinal.DAO;

namespace PVfinal.Services
{
    public class OrderItemService
    {
        public async Task<IEnumerable<OrderItemModel>> GetOrderItemsAsync(int orderId)
        {
            return await Task.Run(() => OrderItemDAO.GetItemsInOrder(orderId));
        }

        public async Task<OrderItemModel> GetOrderItemAsync(int id)
        {
            return await Task.Run(() => OrderItemDAO.GetOrderItem(id));
        }

        public async Task AddOrderItemAsync(OrderItemModel item)
        {
            await Task.Run(() => OrderItemDAO.AddOrderItem(item));
        }

        public async Task UpdateOrderItemAsync(OrderItemModel item)
        {
            await Task.Run(() => OrderItemDAO.UpdateOrderItem(item));
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await Task.Run(() => OrderItemDAO.DeleteOrderItem(id));
        }
    }
}
