using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVfinal.Services
{
    public class UserService
    {

        public Task<List<UserModel>> GetUsersAsync()
        {
            // Simulace získání dat z databáze
            return Task.FromResult(new List<UserModel>
            {
                new UserModel { Id = 1, Username = "Petr", Balance = 100.00m },
                new UserModel { Id = 2, Username = "Jana", Balance = 150.75m }
            });
        }

        public Task AddUserAsync(UserModel user)
        {
            // Simulace přidání uživatele do databáze
            return Task.CompletedTask;
        }
    }
}
