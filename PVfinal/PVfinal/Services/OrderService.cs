using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;
using PVfinal.DAO;

namespace PVfinal.Services
{
    public class OrderService
    {
        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            return await Task.Run(() => OrderDAO.GetAllOrders());
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            return await Task.Run(() => OrderDAO.GetOrder(id));
        }

        public async Task AddOrderAsync(OrderModel order)
        {
            await Task.Run(() => OrderDAO.AddOrder(order));
        }

        public async Task UpdateOrderAsync(OrderModel order)
        {
            await Task.Run(() => OrderDAO.UpdateOrder(order));
        }

        public async Task DeleteOrderAsync(int id)
        {
            await Task.Run(() => OrderDAO.DeleteOrder(id));
        }
    }
}
