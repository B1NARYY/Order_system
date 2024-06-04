using System.Collections.Generic;
using Xunit;
using PVfinal.DAO;
using PVfinal.Models;


namespace PVfinal.Tests
{
    public class OrderItemDAOTests
    {
        [Fact]
        public void AddOrderItem_ShouldAddItem()
        {
            // Arrange
            var item = new OrderItemModel
            {
                OrderId = 1,
                ItemId = 1,
                Quantity = 2
            };

            // Act
            OrderItemDAO.AddOrderItem(item);

            // Assert
            var result = OrderItemDAO.GetOrderItem(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.OrderId, result.OrderId);
            Assert.Equal(item.ItemId, result.ItemId);
            Assert.Equal(item.Quantity, result.Quantity);
        }

        [Fact]
        public void DeleteOrderItemsByOrderId_ShouldDeleteItems()
        {
            // Arrange
            int orderId = 1;

            // Act
            OrderItemDAO.DeleteOrderItemsByOrderId(orderId);

            // Assert
            var items = OrderItemDAO.GetItemsInOrder(orderId);
            Assert.Empty(items);
        }

        [Fact]
        public void UpdateOrderItem_ShouldUpdateItem()
        {
            // Arrange
            var item = new OrderItemModel
            {
                Id = 1,
                OrderId = 1,
                ItemId = 1,
                Quantity = 2
            };

            OrderItemDAO.AddOrderItem(item);
            item.Quantity = 5;

            // Act
            OrderItemDAO.UpdateOrderItem(item);

            // Assert
            var result = OrderItemDAO.GetOrderItem(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.Quantity, result.Quantity);
        }
    }
}
