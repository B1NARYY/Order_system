using System.Collections.Generic;
using Xunit;
using PVfinal.DAO;
using PVfinal.Models;

namespace PVfinal.Tests
{
    public class ItemDAOTests
    {
        [Fact]
        public void AddItem_ShouldAddItem()
        {
            // Arrange
            var item = new ItemModel
            {
                ItemName = "Test Item",
                Price = 10.0m
            };

            // Act
            ItemDAO.AddItem(item);

            // Assert
            var result = ItemDAO.GetItem(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.ItemName, result.ItemName);
            Assert.Equal(item.Price, result.Price);
        }

        [Fact]
        public void DeleteItem_ShouldDeleteItem()
        {
            // Arrange
            var item = new ItemModel
            {
                ItemName = "Test Item",
                Price = 10.0m
            };

            ItemDAO.AddItem(item);

            // Act
            ItemDAO.DeleteItem(item.Id);

            // Assert
            var result = ItemDAO.GetItem(item.Id);
            Assert.Null(result);
        }

        [Fact]
        public void UpdateItem_ShouldUpdateItem()
        {
            // Arrange
            var item = new ItemModel
            {
                ItemName = "Test Item",
                Price = 10.0m
            };

            ItemDAO.AddItem(item);
            item.Price = 20.0m;

            // Act
            ItemDAO.UpdateItem(item);

            // Assert
            var result = ItemDAO.GetItem(item.Id);
            Assert.NotNull(result);
            Assert.Equal(item.Price, result.Price);
        }

        [Fact]
        public void GetAllItems_ShouldReturnItems()
        {
            // Act
            var result = ItemDAO.GetAllItems();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
