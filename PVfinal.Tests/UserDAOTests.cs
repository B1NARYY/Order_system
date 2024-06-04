using System.Collections.Generic;
using Xunit;
using PVfinal.DAO;
using PVfinal.Models;

namespace PVfinal.Tests
{
    public class UserDAOTests
    {
        [Fact]
        public void AddUser_ShouldAddUser()
        {
            // Arrange
            var user = new UserModel
            {
                Username = "Test User",
                Balance = 100.0m
            };

            // Act
            UserDAO.AddUser(user);

            // Assert
            var result = UserDAO.GetUser(user.Id);
            Assert.NotNull(result);
            Assert.Equal(user.Username, result.Username);
            Assert.Equal(user.Balance, result.Balance);
        }

        [Fact]
        public void DeleteUser_ShouldDeleteUser()
        {
            // Arrange
            var user = new UserModel
            {
                Username = "Test User",
                Balance = 100.0m
            };

            UserDAO.AddUser(user);

            // Act
            UserDAO.DeleteUser(user.Id);

            // Assert
            var result = UserDAO.GetUser(user.Id);
            Assert.Null(result);
        }

        [Fact]
        public void UpdateUser_ShouldUpdateUser()
        {
            // Arrange
            var user = new UserModel
            {
                Username = "Test User",
                Balance = 100.0m
            };

            UserDAO.AddUser(user);
            user.Balance = 200.0m;

            // Act
            UserDAO.UpdateUser(user);

            // Assert
            var result = UserDAO.GetUser(user.Id);
            Assert.NotNull(result);
            Assert.Equal(user.Balance, result.Balance);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnUsers()
        {
            // Act
            var result = UserDAO.GetAllUsers();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
