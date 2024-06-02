using System.Collections.Generic;
using System.Threading.Tasks;
using PVfinal.Models;
using PVfinal.DAO;

namespace PVfinal.Services
{
    public class UserService
    {
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await Task.Run(() => UserDAO.GetAllUsers());
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            return await Task.Run(() => UserDAO.GetUser(id));
        }

        public async Task AddUserAsync(UserModel user)
        {
            await Task.Run(() => UserDAO.AddUser(user));
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            await Task.Run(() => UserDAO.UpdateUser(user));
        }

        public async Task DeleteUserAsync(int id)
        {
            await Task.Run(() => UserDAO.DeleteUser(id));
        }
    }
}
