using System;
using System.Collections.Generic;
using Xunit;
using PVfinal.DAO;
using PVfinal.Models;

namespace PVfinal.Tests
{
    public class OrderDAOTests
    {
        [Fact]
        public void AddOrder_ShouldAddOrder()
        {
            // Arrange
            var order = new OrderModel
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItemModel>
                {
                    new OrderItemModel { ItemId = 1, Quantity = 2 }
                }
            };

            // Act
            OrderDAO.AddOrder(order);

            // Assert
            var result = OrderDAO.GetOrder(order.Id);
            Assert.NotNull(result);
            Assert.Equal(order.UserId, result.UserId);
        }

        [Fact]
        public void DeleteOrder_ShouldDeleteOrder()
        {
            // Arrange
            int orderId = 1;

            // Act
            OrderDAO.DeleteOrder(orderId);

            // Assert
            var result = OrderDAO.GetOrder(orderId);
            Assert.Null(result);
        }

        [Fact]
        public void UpdateOrder_ShouldUpdateOrder()
        {
            // Arrange
            var order = new OrderModel
            {
                Id = 1,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItemModel>
                {
                    new OrderItemModel { ItemId = 1, Quantity = 2 }
                }
            };

            OrderDAO.AddOrder(order);
            order.OrderDate = DateTime.Now.AddDays(1);

            // Act
            OrderDAO.UpdateOrder(order);

            // Assert
            var result = OrderDAO.GetOrder(order.Id);
            Assert.NotNull(result);
            Assert.Equal(order.OrderDate, result.OrderDate);
        }
    }
}
